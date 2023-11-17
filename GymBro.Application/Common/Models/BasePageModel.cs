using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GymBro.Application.Common.Models
{
    public class BasePageModel
    {
        private int _page = 1;
        private int _size = 1;
        public int PageNumber
        {
            get { return _page; }
            set
            {
                _page = value;
                if (_page < 1)
                    _page = 1;
                
            }
        }
        public int PageSize
        {
            get { return _size; }
            set
            {
                _size = value;
                if (_size > 200)
                    _size = 200;

            }
        }
        public SortDir SortDir { get; set; }
    }
    public enum SortDir
    {
        Asc,
        Desc
    }
}
