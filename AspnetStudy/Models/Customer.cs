using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspnetStudy.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime? Birthdate { get; set; }    //생년월일
        public bool IsSubscribedToNewsletter { get; set; }  //뉴스레터 구독 여부

        /* Navigation Property */
        public MembershipType MembershipType { get; set; }  //멤버십

        /* FK */
        public byte MembershipTypeId { get; set; }  //멤버십 유형

    }
}