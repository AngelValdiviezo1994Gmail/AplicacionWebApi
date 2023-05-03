using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApisConsumoAsync
    {
        Task<(bool Success, object Data)> GetEndPoint(object request, string uriEndPoint, string nombreEndPoint);

        Task<(bool Success, object Data)> PostEndPoint(object request, string uriEndPoint, string nombreEndPoint);

        Task<(bool Success, object Data)> PutEndPoint(object request, string uriEndPoint, string nombreEndPoint);

    }
}
