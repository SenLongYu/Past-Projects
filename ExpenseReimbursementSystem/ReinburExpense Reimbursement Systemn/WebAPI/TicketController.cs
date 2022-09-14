namespace Controllers;
using TicketService;
using ticketModels;
using customExceptions;

public class TicketController
{
    private readonly TicketServices _TServices;

    public TicketController(TicketServices TicketServices)
    {
        _TServices = TicketServices;
    }

    public IResult CreateReimbursement(Ticket NewTicket) //let us ignore that fact that Created does not return URI for now
    {
        if(NewTicket.reason == null)
        {
            return Results.BadRequest("Reason Cannot Be Null");
        }
        try
        {
            int returnID = _TServices.CreateReimbursement(NewTicket); //I think this has to happen in another line for the try catch to work
            return Results.Created($"/ticket/ticketid?id={returnID}", returnID);
        }
        catch(Exception)
        {
            return Results.Conflict("Something has gone wrong, please try again");
        }
    }

    public IResult UpdateReimbursement(Ticket Ticket2Update)
    {
        if(Ticket2Update.reason == null)
        {
            return Results.BadRequest("Reason Cannot Be Null");
        }
        try
        {
            bool success = _TServices.UpdateReimbursement(Ticket2Update); //I think this has to happen in another line for the try catch to work
            return Results.Created("/ticket/update", success);
        }
        catch(RecordNotFoundException)
        {
            return Results.Conflict("Cannot find the ticket you are trying to update");
        }
    }

    public IResult GetReimbursementByStatus(Status Status2Get)
    {
        try
        {
            List<Ticket> TicketList = _TServices.GetReimbursementByStatus(Status2Get); //I think this has to happen in another line for the try catch to work
            return Results.Ok(TicketList);
        }
        catch(RecordNotFoundException)
        {
            return Results.Conflict("Cannot find the ticket you are trying to find");
        }
    }

    public IResult GetReimbursementByAuthor(int AuthorID)
    {
        try
        {
            List<Ticket> TicketList = _TServices.GetReimbursementByAuthor(AuthorID); //I think this has to happen in another line for the try catch to work
            return Results.Ok(TicketList);
        }
        catch(RecordNotFoundException)
        {
            return Results.Conflict("Cannot find the ticket you are trying to find");
        }
    }

    public IResult GetReimbursementByID(int ID2Get)
    {
        try
        {
            Ticket TicketList = _TServices.GetReimbursementByID(ID2Get); //I think this has to happen in another line for the try catch to work
            return Results.Ok(TicketList);
        }
        catch(RecordNotFoundException)
        {
            return Results.Conflict("Cannot find the ticket you are trying to find");
        }
    }
}