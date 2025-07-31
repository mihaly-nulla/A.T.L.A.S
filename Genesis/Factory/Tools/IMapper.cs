using System;
using System.Collections.Generic;
using System.Text;

namespace Genesis.Factory.Tools
{
    public interface IMapper<TSource, TDestination> // Source sempre será o Domain e o Destination sempre será o DTO
    {
        TDestination ToDTO(TSource source);

        TSource FromDTO(TDestination destination);
    }
}
