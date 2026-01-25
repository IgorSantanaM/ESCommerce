using ESCommerce.Domain.Boxes.Events;
using JasperFx.Events;
using Marten.Events.Projections;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ESCommerce.Domain.Boxes.Projections
{
    public class UnSentBox
    {
        public required Guid BoxId { get; set; }
        public string? Status { get; set; }
    }

    public class UnsentBoxProjection : EventProjection
    {
        public UnsentBoxProjection()
        {
            const string READY_TO_SEND_STATUS = "Ready To Send!";

            Project<IEvent<BoxCreated>>((evt, operations) =>
            {
                operations.Store(new UnSentBox
                {
                    BoxId = evt.StreamId
                });
            });

            Project<IEvent<BoxSent>>((evt, operations) =>
            {
                operations.Delete<UnSentBox>(evt.StreamId);
            });

            ProjectAsync<IEvent<BoxClosed>>(async (evt, operations, token) =>
            {
                var unsentBox = await operations.LoadAsync<UnSentBox>(evt.StreamId);

                if (unsentBox is null)
                    return;

                unsentBox.Status = READY_TO_SEND_STATUS;

                operations.Store(unsentBox);
            });
        }
    }
}
