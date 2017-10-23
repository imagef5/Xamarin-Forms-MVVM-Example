namespace MVVMBasic.Models
{
    /// <summary>
    /// 이용자 정보
    /// </summary>
    public class User
    {
        /// <summary>
        /// 성별
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// 이름
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 이름
        /// </summary>
        public string LasttName { get; set; }
        /// <summary>
        /// 주소
        /// </summary>
        public Address Address { get; set; }
        /// <summary>
        /// 이메일
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 사진 Uri 
        /// </summary>
        public string Picture { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
    }
}
