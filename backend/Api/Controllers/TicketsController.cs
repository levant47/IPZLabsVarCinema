using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IPZLabsVarCinema
{
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;

        public TicketsController(CinemaDbContext dbContext) => _dbContext = dbContext;

        public object GetByUserId([FromQuery] int userId) => _dbContext.Tickets
            .Where(ticket => ticket.UserId == userId)
            .Select(ticket => new TicketVM
            (
                /* MovieName: */ ticket.Session.Movie.Name,
                /* SessionStartTime: */ ticket.Session.StartTime,
                /* HallName: */ ticket.Session.Hall.Name,
                /* Row: */ ticket.SeatRow,
                /* Seat: */ ticket.SeatIndex
            ))
            .ToList();

        public record BuyBodySeat(int SeatRow, int SeatIndex);
        public record BuyBody(int UserId, int SessionId, List<BuyBodySeat> Seats);
        [HttpPost("buy")]
        public object Buy([FromBody] BuyBody body)
        {
            var now = DateTime.Now;
            _dbContext.Tickets.AddRange(body.Seats.Select(seat => new Ticket
            (
                Id: 0,
                UserId: body.UserId,
                SessionId: body.SessionId,
                SeatRow: seat.SeatRow,
                SeatIndex: seat.SeatIndex,
                PurchaseTime: now
            )));
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
