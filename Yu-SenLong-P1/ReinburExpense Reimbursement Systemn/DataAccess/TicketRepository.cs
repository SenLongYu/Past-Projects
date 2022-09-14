namespace TickeData;
using ticketModels;
using ConnectionFactory;
using System.Data.SqlClient;
using customExceptions; 

public class TicketRepository
{
    private int TicketID;
    private string TicketReason;
    private int TicketAuthor;
    private int? TicketResolver;
    private Status TicketStatus;
    private string StringStatus;
    private Decimal TicketAmount;
    private readonly ConnectionFactoryClass _ConnectionFactory;
    public TicketRepository(ConnectionFactoryClass ConnectionFactory)
    {
        _ConnectionFactory = ConnectionFactory;
    }
    /// <summary>
    /// Retrieves the tickets with the given ID from the data base
    /// </summary>
    /// <param name="ID2Get"></param>
    /// <returns>A ticket item that match the input ID</returns>
    /// <exception cref="RecordNotFoundException">Occurs if no tickets exist matching the given ID</exception>
    public Ticket GetReimbursementByID(int ID2Get)
    {
        Ticket ReturnTicket = new Ticket();
        SqlConnection connection = _ConnectionFactory.GetConnection(); //get a hold of the server
        string sql = "select * from ERS_P1.tickets where ID = @ID2Get;";
        SqlCommand command = new SqlCommand (sql, connection);
        command.Parameters.AddWithValue("@ID2Get",ID2Get);
        bool successful = false; //indicating if the read is successful

        try
        {
            //opening the connection to the database
            connection.Open();
            //storing the result set of the DQL statement into a variable
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read()) //I have no idea if/how this works
            {
                TicketID = (int) reader[0];
                TicketReason = (String)reader[1];
                StringStatus = (string)reader[2];
                TicketAuthor = (int)reader[3];
                TicketAmount = (Decimal)reader[5];
                successful = true;

                if(StringStatus == "Approved")
                {
                    TicketStatus = Status.Approved;
                }
                else if(StringStatus == "Denied")
                {
                    TicketStatus = Status.Denied;
                }
                else
                {
                    TicketStatus = Status.Pending;
                }

                if(reader[4] == DBNull.Value)
                {
                    TicketResolver = null;
                }
                else
                {
                    TicketResolver = (int)reader[4];
                }
                ReturnTicket = new Ticket(TicketReason,TicketID,TicketAuthor,TicketResolver,TicketAmount, TicketStatus);
            }
            reader.Close();
            connection.Close();
        }
        catch(Exception)
        {
            throw;
        }
        if(successful)
        {
            return ReturnTicket;
        }
        throw new RecordNotFoundException();
    }
    /// <summary>
    /// Retrieves all tickets with the given status from the data base
    /// </summary>
    /// <param name="status"></param>
    /// <returns>A list of Ticket that matches the input status</returns>
    /// <exception cref="RecordNotFoundException">Occurs if no tickets exist matching the given status</exception>
    public List<Ticket> GetReimbursementByStatus(Status status) 
    {
        Ticket ReturnTicket;
        List<Ticket> TicketList = new List<Ticket>();
        SqlConnection connection = _ConnectionFactory.GetConnection(); //get a hold of the server
        string sql = "select * from ERS_P1.tickets where status = @StringStatus;";
        if(status == Status.Approved)
        {
            StringStatus = "Approved";
        }
        else if(status == Status.Denied)
        {
            StringStatus = "Denied";
        }
        else
        {
            StringStatus = "Pending";
        }
        SqlCommand command = new SqlCommand (sql, connection);
        command.Parameters.AddWithValue("@StringStatus",StringStatus);

        try
        {
            //opening the connection to the database
            connection.Open();
            //storing the result set of the DQL statement into a variable
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read()) //I have no idea if/how this works
            {
                TicketID = (int) reader[0];
                TicketReason = (String)reader[1];
                StringStatus = (string)reader[2];
                TicketAuthor = (int)reader[3];
                TicketAmount = (Decimal)reader[5];

                if(StringStatus == "Approved")
                {
                    TicketStatus = Status.Pending;
                }
                else if(StringStatus == "Denied")
                {
                    TicketStatus = Status.Pending;
                }
                else
                {
                    TicketStatus = Status.Pending;
                }

                if(reader[4] == DBNull.Value)
                {
                    TicketResolver = null;
                }
                else
                {
                    TicketResolver = (int)reader[4];
                }
                ReturnTicket = new Ticket(TicketReason,TicketID,TicketAuthor,TicketResolver,TicketAmount, TicketStatus);
                TicketList.Add(ReturnTicket);
            }
            reader.Close();
            connection.Close();
        }
        catch(Exception)
        {
            throw;
        }

        if(TicketList.Any()) //this checks if the list has any element
        {
            return TicketList;
        }
        throw new RecordNotFoundException(); 
    } //Untested Method, but it probably works. I will fix it once it actually breaks
    /// <summary>
    /// Retrieves the tickets by a particular author from the data base
    /// </summary>
    /// <param name="AuthorID"></param>
    /// <returns>A list of ticket items are submitted by the Author</returns>
    /// <exception cref="RecordNotFoundException">Occurs if no tickets exist matching the given AuthorID</exception>
    public List<Ticket> GetReimbursementByAuthor(int AuthorID)
    {
        Ticket ReturnTicket;
        List<Ticket> TicketList = new List<Ticket>();
        SqlConnection connection = _ConnectionFactory.GetConnection(); //get a hold of the server
        string sql = "select * from ERS_P1.tickets where authorID = @AuthorID;";
        SqlCommand command = new SqlCommand (sql, connection);
        command.Parameters.AddWithValue("@AuthorID",AuthorID);

        try
        {
            //opening the connection to the database
            connection.Open();
            //storing the result set of the DQL statement into a variable
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read()) //I have no idea if/how this works
            {
                TicketID = (int) reader[0];
                TicketReason = (String)reader[1];
                StringStatus = (string)reader[2];
                TicketAuthor = (int)reader[3];
                TicketAmount = (Decimal)reader[5];

                if(StringStatus == "Approved")
                {
                    TicketStatus = Status.Approved;
                }
                else if(StringStatus == "Denied")
                {
                    TicketStatus = Status.Denied;
                }
                else
                {
                    TicketStatus = Status.Pending;
                }

                if(reader[4] == DBNull.Value)
                {
                    TicketResolver = null;
                }
                else
                {
                    TicketResolver = (int)reader[4];
                }
                ReturnTicket = new Ticket(TicketReason,TicketID,TicketAuthor,TicketResolver,TicketAmount, TicketStatus);
                TicketList.Add(ReturnTicket);
            }
            reader.Close();
            connection.Close();
        }
        catch(Exception)
        {
            throw;
        }

        if(TicketList.Any()) //this checks if the list has any element
        {
            return TicketList;
        }
        throw new RecordNotFoundException(); 
    } //Untested Method, but it probably works. I will fix it once it actually breaks
    /// <summary>
    /// takes an ticket item and returns true for successful creation
    /// </summary>
    /// <param name="NewTicket"></param>
    /// <returns>true for a succssful creation, flase if not</returns>
    public int CreateReimbursement(Ticket NewTicket) 
    {
        SqlConnection connection = _ConnectionFactory.GetConnection(); //get a hold of the server
        string sql = "insert into ERS_P1.tickets (reason,status,authorID,resolverID,amount) OUTPUT Inserted.ID values (@TicketReason,@StringStatus,@TicketAuthor,@TicketResolver,@TicketAmount);";
        SqlCommand command = new SqlCommand (sql, connection);

        TicketID = NewTicket.ID; //convert everything down to a single variable, there are better way to do this
        TicketReason = NewTicket.reason;
        TicketAuthor = NewTicket.authorID;
        if(TicketResolver==null)
        {
            command.Parameters.AddWithValue("@TicketResolver",DBNull.Value);
        }
        else
        {
            TicketResolver = NewTicket.resolverID;
            command.Parameters.AddWithValue("@TicketResolver",TicketResolver);
        }
        TicketStatus = NewTicket.status;
        TicketAmount = NewTicket.amount;
        if(TicketStatus == Status.Approved)
        {
            StringStatus = "Approved";
        }
        else if(TicketStatus == Status.Denied)
        {
            StringStatus = "Denied";
        }
        else
        {
            StringStatus = "Pending";
        }
        
        command.Parameters.AddWithValue("@TicketReason",TicketReason); //adding all the value to the parameters
        command.Parameters.AddWithValue("@StringStatus",StringStatus); //this is a mess
        command.Parameters.AddWithValue("@TicketAuthor",TicketAuthor); //there has to be a better way to do this
        command.Parameters.AddWithValue("@TicketAmount",TicketAmount);

        try
        {
            //opening the connection to the database
            connection.Open();

            //for DML statements
            int returnID = (int)command.ExecuteScalar(); //according to the document, this would be null if the result set is empty

            connection.Close();

            return returnID;
        }
        catch(Exception e)
        {
            throw;
        }
    }
    /// <summary>
    /// update the ticket, currently takes a ticket object, and overwrites the corresponding ticket with the new one
    /// </summary>
    /// <param name="Ticket2Update"></param>
    /// <returns>true if the update is successful, false if it is not</returns>
    /// <exception cref="RecordNotFoundException">Occurs if no tickets exist matching the given ID</exception>
    public bool UpdateReimbursement(Ticket Ticket2Update) 
    {
        SqlConnection connection = _ConnectionFactory.GetConnection(); //get a hold of the server
        string sql = "update ERS_P1.tickets set reason = @TicketReason, status = @StringStatus, authorID=@TicketAuthor, resolverID=@TicketResolver, amount=@TicketAmount where ID=@TicketID;";
        SqlCommand command = new SqlCommand (sql, connection);

        TicketID = Ticket2Update.ID; //convert everything down to a single variable, there are better way to do this
        TicketReason = Ticket2Update.reason; //this process should probably be turned into a method by itself
        TicketAuthor = Ticket2Update.authorID;
        TicketResolver = Ticket2Update.resolverID;
        TicketStatus = Ticket2Update.status;
        TicketAmount = Ticket2Update.amount;
        if(TicketStatus == Status.Approved)
        {
            StringStatus = "Approved";
        }
        else if(TicketStatus == Status.Denied)
        {
            StringStatus = "Denied";
        }
        else
        {
            StringStatus = "Pending";
        }
        
        command.Parameters.AddWithValue("@TicketReason",TicketReason); //adding all the value to the parameters
        command.Parameters.AddWithValue("@StringStatus",StringStatus); //this is a mess
        command.Parameters.AddWithValue("@TicketAuthor",TicketAuthor); //there has to be a better way to do this
        command.Parameters.AddWithValue("@TicketResolver",TicketResolver);
        command.Parameters.AddWithValue("@TicketAmount",TicketAmount);
        command.Parameters.AddWithValue("@TicketID",TicketID);

        try
        {
            //opening the connection to the database
            connection.Open();

            //for DML statements
            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            if(rowsAffected==0) //this should work if there are no tickets matching the ID given
            {
                throw new RecordNotFoundException();
            }
                return true;
        }
        catch(Exception)
        {
            throw;
        }
    }
}