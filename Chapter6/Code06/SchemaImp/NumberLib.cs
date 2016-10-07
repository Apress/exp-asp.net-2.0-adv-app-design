using System.Xml.Serialization;

namespace NumberLib
{
    [XmlRoot("phoneNumber", Namespace = "http://phoneNumber/", IsNullable = true)]
    public class PhoneNumber
    {
        public PhoneNumber() { }

        public PhoneNumber(
            string AreaCode,
            string Number,
            PhoneType NumberType)
        {
            this.AreaCode = AreaCode;
            this.Number = Number;
            this.NumberType = NumberType;
        }

        private string m_AreaCode;
        public string AreaCode
        {
            get { return m_AreaCode; }
            set { m_AreaCode = value; }
        }

        private string m_Number;
        public string Number
        {
            get { return m_Number; }
            set
            {
                value = value.Replace("-", "");
                value = value.Replace(" ", "");
                if (value.Length != 7)
                    throw new System.Exception("Number must be seven digits");

                m_Number = value;
            }
        }

        //State plus Behavior
        private PhoneType m_NumberType;
        public PhoneType NumberType
        {
            get { return m_NumberType; }
            set { m_NumberType = value; }
        }

        public string FormattedNumber()
        {
            return string.Format("({0}){1}-{2}({3})",
                this.AreaCode,
                this.Number.Substring(0, 3),
                this.Number.Substring(3, 4),
                this.NumberType.ToString().Substring(0, 1));
        }
    }

    public enum PhoneType
    {
        Home,
        Work,
        Office,
        Fax,
        Cell
    }
}