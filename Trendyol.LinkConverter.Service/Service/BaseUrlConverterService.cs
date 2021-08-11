using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.LinkConverter.Core;

namespace Trendyol.LinkConverter.Service
{
    public abstract class BaseUrlConverterService
    {
        public abstract UrlConverterStrategyType FindUrlConverterStrategy(string url);
    }
}
