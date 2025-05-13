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

        public void CalculateAspectRatioString() {
            // Replacement strings are the 32‑bit IEEE‑754 encoding of the exact aspect‑ratio float, in little‑endian byte order.
            float decimalAspectRatio = (float)Width / (float)Height;
            byte[] bytes = BitConverter.GetBytes(decimalAspectRatio);
            ReplacementString = BitConverter.ToString(bytes).Replace("-", "");
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