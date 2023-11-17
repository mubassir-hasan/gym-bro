using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Application.Common.Models
{
    public class ChartListItemDTO
    {
        public ChartListItemDTO(DateTime x, int y)
        {
            X = x.ToString("yyyy-MM-dd");
            Y = y.ToString();
        }
        public ChartListItemDTO(string? x, int y)
        {
            X = x;
            Y = y.ToString();
        }
        public ChartListItemDTO(string? x, string y)
        {
            X = x;
            Y = y;
        }
        public ChartListItemDTO(string? x, float y)
        {
            X = x;
            Y = $"{y:0.00}";
        }
        public ChartListItemDTO(string? x, double y)
        {
            X = x;
            Y = $"{y:0.00}";
        }

        public string? X { get; set; } = "";
        public string Y { get; set; } = "";
    }
}
