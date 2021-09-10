namespace Nagarro.Sample.Shared
{
    /// <summary>
    /// Business Domain Component Type
    /// </summary>
    public enum BDCType
    {
        /// <summary>
        /// Undefined BDC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.Sample.Business.dll", "Nagarro.Sample.Business.UserBDC")]
        UserBDC = 1,

        [QualifiedTypeName("Nagarro.Sample.Business.dll", "Nagarro.Sample.Business.EventBDC")]
        EventBDC = 2,

        [QualifiedTypeName("Nagarro.Sample.Business.dll", "Nagarro.Sample.Business.PostedCommentsBDC")]
        PostedCommentsBDC = 3

    }
}
