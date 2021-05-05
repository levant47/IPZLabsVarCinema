using System.Collections.Generic;

namespace IPZLabsVarCinema
{
    public interface ITicketsService
    {
        List<TicketDto> BuyTicketsForUser(int userId, List<TicketDto> ticketPurchases);

        List<TicketDto> GetActiveForUser(int userId);

        void RefundTicket(int ticketId);
    }
}
