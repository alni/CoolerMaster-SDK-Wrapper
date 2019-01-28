namespace CoolerMasterSharpSDK.Datatypes
{
    /// <summary>
    /// Set/store entire LED Color structure
    /// </summary>
    public class ColorMatrix
    {
        public KeyColor[,] KeyColors { get; set; }

        public ColorMatrix()
        {
            KeyColors = new KeyColor[CoolerMasterSDK.MaxLedRow, CoolerMasterSDK.MaxLedColumn];
        }
    }
}
