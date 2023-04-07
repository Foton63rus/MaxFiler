namespace MaxFiler.Palette
{
    [Serializable]
    public readonly struct PreviewSlot
    {
        public readonly string image;
        public readonly string[] colors;

        public PreviewSlot(string imagePath, string[] colorsNames, int maxColors = 5)
        {
            image = imagePath;
            if (colorsNames.Count() > maxColors)
            {
                colors = colorsNames.Take(maxColors).ToArray();
            }
            colors = colorsNames;
        }
    }
}
