using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating.Context
{
    public interface IFilePolicyLoader
    {
        string LoadPolicyFromFile(string file);
    }
}
