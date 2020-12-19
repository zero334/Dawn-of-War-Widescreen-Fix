using System;
using System.Collections.Generic;

namespace Dawn_of_War_Widescreen_Fix
{
    class AttributeStorage
    {
        public ushort Width { get; set; }
        public ushort Height { get; set; }
        public String AspectRatio { get; set; }
        public String ReplacementString { get; set; }
        public String BaseString { get; private set; }
        public FileStorage FileStorage { get; set; }

        public AttributeStorage()
        {
            Width = 0;
            Height = 0;
            AspectRatio = "";
            ReplacementString = "";
            BaseString = "ABAAAA3F";
            FileStorage = new FileStorage();
        }

        public void CalculateAspectRatio()
        {
            ushort greatestCommonDivisor = (ushort)Gcd(Width, Height);
            AspectRatio = (Width / greatestCommonDivisor + "/" + Height / greatestCommonDivisor);
        }

        public void LookupDecimalAspectRatio() {
            Dictionary<float, string> aspectRatiosTable = new Dictionary<float, string>()
            {
                { 1.25f, "0000A03F"}, // 5:4
                { 1.33f, "ABAAAA3F"}, // 4:3
                { 1.5f,  "0000C03F"}, // 3:2
                { 1.6f,  "CDCCCC3F"}, // 16:10
                { 1.66f, "5555D53F"}, // 15:9
                { 1.77f, "398EE33F"}, // 16:9
                { 1.85f, "CDCCEC3F"}, // 1.85:1
                { 2.39f, "C3F51840"}, // 2.39:1
                { 2.76f, "D7A33040"}, // 2.76:1
                { 3.75f, "00007040"}, // 3x5:4
                { 4f   , "00008040"}, // 3x4:3
                { 4.8f , "9A999940"}, // 3x16:10
                { 5f   , "0000A040"}, // 3x15:9
                { 5.33f, "ABAAAA40"}, // 3x16:9
                { 2.37f, "26B41740"}, // 21:9(2560x1080)
                { 2.38f, "8EE31840"}, // 21:9(3440x1440)
                { 2.4f , "9A991940"}, // 21:9(3840x1600)
                { 3.2f , "CDCC4C40"}, // 32:10
                { 3.55f, "398E6340"}  // 32:9
            };

            double decimalAspectRatio = (double)Width / (double)Height;
            decimalAspectRatio = Math.Truncate(100 * decimalAspectRatio) / 100;

            if (aspectRatiosTable.TryGetValue((float)decimalAspectRatio, out string aspectRatioBuffer)) {
                ReplacementString = aspectRatioBuffer;
            }
        }

        public bool CheckAspectRatioValues()
        {
            return Width > 0 && Height > 0 && AspectRatio.Length > 1 && ReplacementString.Length > 0;
        }

        public String CheckFileStorage()
        {
            return (!FileStorage.LocalIni.Item2) ? "Local.ini not found!\nStart the game once so that the file will be created." : "";
        }

        private int Gcd(int n1, int n2)
        {
            return (n2 == 0) ? n1 : Gcd(n2, n1 % n2);
        }
    }
}