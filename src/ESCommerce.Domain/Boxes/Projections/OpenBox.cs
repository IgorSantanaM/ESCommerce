using ESCommerce.Domain.Boxes.Events;
using JasperFx.Events;
using JasperFx.Events.Projections;
using Marten.Events.Projections;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESCommerce.Domain.Boxes.Projections
{
    public class OpenBox
    {
        public required Guid BoxId { get; set; }
        public required int Capacity { get; set; }
        public int? NumberOfProducts { get; set; } 
    }
    public class OpenBoxProjection : EventProjection
    {
        public OpenBoxProjection()
        {
            Project<IEvent<BoxCreated>>((evt, operations) =>
            {
                operations.Store(new OpenBox
                {
                    BoxId = evt.StreamId,
                    Capacity = evt.Data.DesiredNumberOfSpots
                });
            });

            Project<IEvent<BoxClosed>>((evt, operations) =>
            {
                operations.Delete<OpenBox>(evt.StreamId);
            });

            ProjectAsync<IEvent<ProductAdded>>(async (evt, operations, token) =>
            {
                var openBox = await operations.LoadAsync<OpenBox>(evt.StreamId, token);

                if (openBox is null)
                    return;

                openBox.NumberOfProducts++;
                operations.Store(openBox);
            });
        }
    }


}
