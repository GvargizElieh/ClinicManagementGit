using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities.Validation
{
    public class ValidationMessages
    {
        public const string Required = "وارد کردن این فیلد اجباری است";
        public const string InvalidPhoneNumber = "شماره تلفن نامعتبر است";
        public const string NotFound = "اطلاعات درخواستی یافت نشد";
        public const string MaxLength = "تعداد کاراکتر های وارد شده بیشتر از حد مجاز است";
        public const string MinLength = "تعداد کاراکتر های وارد شده کمتر از حد مجاز است";

        public static string IsRequired(string field) => $"{field} اجباری است ";
        public static string HasMaxLength(string field, int maxLength) => $"{field} باید کمتر از {maxLength} کاراکتر باشد";
        public static string HasMinLength(string field, int minLength) => $"{field} باید بیشتر از {minLength} کاراکتر باشد";
    }
}
