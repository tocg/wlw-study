

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PNet.Study.View.Models
{
    /// <summary>
    /// Model实体类
    /// </summary>
    public class UserRegistModel
    {

        /*
         * 1、Required 必填(默认为不允许为空。允许为空则添加AllowEmptyStrings = true)
         * 2、StringLength 长度
         * 3、Compare 比较
         * 4、RegularExpression 正则
         * 5、Range 范围
         * 6、Remote 回调
         * **/

        //必填
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }

        //必填，长度不超20
        [Required]
        [StringLength(20, ErrorMessage = "设置的密码不能超过20个字符")]
        public string Password { get; set; }

        //必填，两次密码要一致
        [Required]
        [Compare("Password", ErrorMessage = "两次密码不一致")]
        public string ConfirmPassword { get; set; }

        //必填，且是邮箱模式   （@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")）
        [Required]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "邮箱格式不正确")]
        public string Email { get; set; }

        //必填，年龄15-30
        [Required]
        [Range(15, 30, ErrorMessage = "年龄不符合")]
        public int Age { get; set; }

        //验证回调[Remote]

    }
}