using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.LinkConverter.Core;
using Trendyol.LinkConverter.Core.ApiModels;

namespace Trendyol.LinkConverter.Service
{
    public interface IUrlConverterStrategy
    {
        UrlConverterStrategyType StrategyType { get; }
        ResponseModel ConvertUrl(RequestModel requestModel);
    }
}
