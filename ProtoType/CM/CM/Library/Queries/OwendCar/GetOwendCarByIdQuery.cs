using CM.Library.DataModels.BusinessModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Library.Queries.OwnedCar
{
    public class GetOwnedCarByIdQuery : IRequest<OwnedCarDataModel>
    {
        public string Id { get; set; }

        public GetOwnedCarByIdQuery(string id)
        {
            Id = id;
        }
    }
}
