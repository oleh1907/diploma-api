using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaBLL.Analysis
{
    public interface IAnalysisService
    {
        public Task<string> AnalyseImage(string path);
    }
}
