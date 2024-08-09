using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Models.Abstracts
{
    public abstract class ParametrosPaginacao
    {
        const int maxPagesize = 20;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = maxPagesize;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPagesize) ? maxPagesize : value; } //se o valor informado for maior que o maximo , será usado o maximo , se não usa o valor informado
        }
    }
}
