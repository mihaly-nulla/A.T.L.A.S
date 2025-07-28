using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.DTO
{
    public interface IMapper<TSource, TDestination> // Source sempre será o Domain e o Destination sempre será o DTO
    {
        TDestination ToDTO(TSource source);

        TSource FromDTO(TDestination destination);
    }
}
