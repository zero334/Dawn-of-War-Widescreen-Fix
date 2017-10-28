using System;

namespace Dawn_of_War_Widescreen_Fix
{
    class AttributeStorage
    {
        public ushort Width { get; set; }
        public ushort Height { get; set; }
        public String AspectRatio { get; set; }
        public String ReplacementString { get; set; }
        public String BaseString { get; private set; }
        public FileStorage fileStorage { get; set; }

        public AttributeStorage()
        {
            Width = 0;
            Height = 0;
            AspectRatio = "";
            BaseString = "ABAAAA3F";
            fileStorage = new FileStorage();
        }

        public void CalculateAspectRatio()
        {
            ushort greatestCommonDivisor = (ushort)Gcd(Width, Height);
            AspectRatio = (Width / greatestCommonDivisor + "/" + Height / greatestCommonDivisor);
        }

        public bool CheckAspectRatioValues()
        {
            return (Width > 0 && Height > 0 && AspectRatio.Length > 1 && ReplacementString.Length > 0) ? true : false;
        }

        public String CheckFileStorage()
        {
            return (!fileStorage.LocalIni.Item2) ? "Local.ini not found!\nStart the game once so that the file will be created." : "";
        }

        private int Gcd(int n1, int n2)
        {
            return (n2 == 0) ? n1 : Gcd(n2, n1 % n2);
        }
    }
}