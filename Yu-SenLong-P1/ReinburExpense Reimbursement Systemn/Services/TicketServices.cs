namespace TicketService;
using TickeData;
using ticketModels;
using customExceptions; 

public class TicketServices
{//for detailed documentation on each method, see TicketRepo class
    private readonly TicketRepository _TicketRepo;
    public TicketServices(TicketRepository TicketRepo)
    {
        _TicketRepo = TicketRepo;
    }

    public bool UpdateReimbursement(Ticket Ticket2Update)
    {
        
        try
        {
            return _TicketRepo.UpdateReimbursement(Ticket2Update);
        }
        catch(Exception )
        {
            throw;
        }
    }

    public int CreateReimbursement(Ticket NewTicket)
    {
        if(NewTicket.authorID<=0 || NewTicket.resolverID<=0) //Lets only check these two for now
        {
            throw new RecordNotFoundException();
        }
        try
        {
            return _TicketRepo.CreateReimbursement(NewTicket);
        }
        catch(Exception )
        {
            throw;
        }
    }

    public List<Ticket> GetReimbursementByAuthor(int AuthorID)
    {
        try
        {
            return _TicketRepo.GetReimbursementByAuthor(AuthorID);
        }
        catch(Exception )
        {
            throw;
        }
    }

    public List<Ticket> GetReimbursementByStatus(Status status)
    {
        try
        {
            return _TicketRepo.GetReimbursementByStatus(status);
        }
        catch(Exception )
        {
            throw;
        }
    }

    public Ticket GetReimbursementByID(int ID2Get)
    {
        try
        {
            return _TicketRepo.GetReimbursementByID(ID2Get);
        }
        catch(Exception )
        {
            throw;
        }
    }
}