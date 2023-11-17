using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Application.Common.Models
{
    public class DropdownListItemDTO
    {
        public DropdownListItemDTO(string value, string text)
        {
            Value = value;
            Text = text;
        }
        public DropdownListItemDTO(int value, string text)
        {
            Value = value.ToString();
            Text = text;
        }
        public DropdownListItemDTO(long value, string text)
        {
            Value = value.ToString();
            Text = text;
        }
        public DropdownListItemDTO(decimal value, string text)
        {
            Value = value.ToString();
            Text = text;
        }

        public string Value { get; set; } = "";
        public string Text { get; set; } = "";
    }
}
