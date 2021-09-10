namespace Nagarro.Sample.Shared
{
    /// <summary>
    /// Data Access Component Type
    /// </summary>
    public enum DACType
    {
        /// <summary>
        /// Undefined DAC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.Sample.Data.dll", "Nagarro.Sample.Data.UserDAC")]
        UserDAC = 1,

        [QualifiedTypeName("Nagarro.Sample.Data.dll", "Nagarro.Sample.Data.EventDAC")]
        EventDAC = 2,

        [QualifiedTypeName("Nagarro.Sample.Data.dll", "Nagarro.Sample.Data.PostedCommentsDAC")]
        PostedCommentsDAC = 3


    }
}
