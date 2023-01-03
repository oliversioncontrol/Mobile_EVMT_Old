using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Shipping Models
    /// </summary>
   public class ShippingModel
    {
        public int ShippingId { get; set; }
        public string ShipInboundShipDate { get; set; }
        public string ShipInboundDeliveryDate { get; set; }
        public string ShipInboundCarrierId { get; set; }
        public string ShipInboundCarrier { get; set; }
        public string ShipInboundHandling { get; set; }
        public string ShipInboundFrom { get; set; }
        public string ShipInboundCarrierContact { get; set; }
        public string ShipInboundPieces { get; set; }
        public string ShipInboundDescription { get; set; }
        public string ShipInboundPhone { get; set; }
        public string ShipInboundFax { get; set; }
        public string ShipInboundTracking { get; set; }
        public string ShipInboundEmail { get; set; }
        public string ShipOutboundPickupDate { get; set; }
        public string ShipOutboundDeliveryDate { get; set; }
        public string ShipOutboundPickupTime { get; set; }
        public string ShipOutboundDeliveryTime { get; set; }
        public int ShipOutboundCarrierId { get; set; }
        public string ShipOutboundCarrier { get; set; }
        public string ShipOutboundCarrierContact { get; set; }
        public string ShipOutboundPieces { get; set; }
        public string ShipOutboundDescription { get; set; }
        public string ShipOutboundPhone { get; set; }
        public string ShipOutboundFax { get; set; }
        public string ShipOutboundTracking { get; set; }
        public string ShipOutboundEmail { get; set; }
        public string ShipToOutboundTo { get; set; }
        public string ShipToName { get; set; }
        public string ShipToAttn { get; set; }
        public string ShipToAddress { get; set; }
        public string ShipBillingTo { get; set; }
        public string ShipBillingName { get; set; }
        public string ShipBillingAttn { get; set; }
        public string ShipBillingAddress { get; set; }
        public string ShipNotes { get; set; }
    }
}
