using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspnetStudy.Models
{
    public class MembershipType //멤버십
    {
        public byte Id { get; set; }    //PK

        [Required]
        public string Name { get; set; }    //멤버십명
        public short SignUpFee { get; set; }    //구독료
        public byte DurationInMonths { get; set;}       //구독 기간
        public byte DiscountRate { get; set;}   //할인율
    }
}