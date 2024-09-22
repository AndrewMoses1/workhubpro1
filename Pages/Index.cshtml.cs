using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.Cosmos;
using Entry = workhubpro.Models.Entry;


namespace workhubpro.Pages;

public class IndexModel : PageModel
{
    private readonly CosmosClient _client;
    private readonly Container _container;
    public List<Entry>? Entry1 { get; private set; }
    

    // This constructor contains all of the necessary components to connect to a CosmosDB database.
    public IndexModel(CosmosClient client, IConfiguration configuration)
    {
        _client = client;
        var databaseId = configuration["CosmosDbSettings:DatabaseName"];
        var containerId = configuration["CosmosDbSettings:ContainerName"];
        _container = _client.GetContainer(databaseId, containerId);
    }


    // This method retrieves the entrie's information (if there is any and the categories aren't empty) and then applies it to the application on page load.
    public async Task OnGetAsync()
    {
        string id = "2345";
        Entry1 = new List<Entry>();
        string query = $"SELECT * FROM c WHERE c.id = '{id}'";
        using (FeedIterator<Entry> feedIterator = _container.GetItemQueryIterator<Entry>(new QueryDefinition(query)))
        {
            while (feedIterator.HasMoreResults) {
                FeedResponse<Entry> response = await feedIterator.ReadNextAsync();
                Entry1.AddRange(response);
            }
        }
    }

    // This method allows the user to login with the 'username: admin, password: admin' credentials.
    public async Task<IActionResult> OnPostLogin(string Username, string Password)
    {
        try
        {
            string query = "SELECT * FROM c WHERE c.Username = @username AND c.Password = @password";
            var queryDefinition = new QueryDefinition(query)
                .WithParameter("@username", Username)
                .WithParameter("@password", Password);
            var queryIterator = _container.GetItemQueryIterator<dynamic>(queryDefinition);
            if (queryIterator.HasMoreResults)
            {
                var response = await queryIterator.ReadNextAsync();
                if (response.Count > 0)
                {
                    return new OkResult();
                }
                else
                {
                    return new BadRequestResult();
                }
            }
            else
            {
                Console.WriteLine("Query iterator has no more results");
                return new BadRequestResult();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new StatusCodeResult(500);
        }
    }
    
    // This method allows the user to save the current state of the application by replacing the already existing CosmosDB document with an updated version.
    public async Task<IActionResult> OnPostReplace(string[] urgentTaskValue, string[] urgentTeamImage1, string[] urgentTeamImage2, string[] urgentTeamImage3,
                                                   string[] urgentTeamImage4, string[] urgentTeamImage5, string[] urgentTeamImage6, string[] urgentTeamImage7,
                                                   string[] urgentTeamImage8, string[] urgentStatusTextContent, string[] urgentStatusColor,
                                                   string[] urgentDescriptionTextContent, string[] urgentProgressPercentage,
                                                   string[] urgentProgressPercentageParsed, string[] urgentProgressPercentageFontSize,
                                                   string[] urgentProgressPercentageBackground, string[] urgentProgressWidth, string[] urgentProgressMaxWidth,
                                                   string[] urgentProgressCompleteOpacity, string[] thisMonthTaskValue, string[] thisMonthTeamImage1,
                                                   string[] thisMonthTeamImage2, string[] thisMonthTeamImage3, string[] thisMonthTeamImage4,
                                                   string[] thisMonthTeamImage5, string[] thisMonthTeamImage6, string[] thisMonthTeamImage7,
                                                   string[] thisMonthTeamImage8, string[] thisMonthStatusTextContent, string[] thisMonthStatusColor,
                                                   string[] thisMonthDescriptionTextContent, string[] thisMonthProgressPercentage,
                                                   string[] thisMonthProgressPercentageParsed, string[] thisMonthProgressPercentageFontSize,
                                                   string[] thisMonthProgressPercentageBackground, string[] thisMonthProgressWidth,
                                                   string[] thisMonthProgressMaxWidth, string[] thisMonthProgressCompleteOpacity, string[] nextMonthTaskValue,
                                                   string[] nextMonthTeamImage1, string[] nextMonthTeamImage2, string[] nextMonthTeamImage3,
                                                   string[] nextMonthTeamImage4, string[] nextMonthTeamImage5, string[] nextMonthTeamImage6,
                                                   string[] nextMonthTeamImage7, string[] nextMonthTeamImage8, string[] nextMonthStatusTextContent,
                                                   string[] nextMonthStatusColor, string[] nextMonthDescriptionTextContent, string[] nextMonthProgressPercentage,
                                                   string[] nextMonthProgressPercentageParsed, string[] nextMonthProgressPercentageBackground,
                                                   string[] nextMonthProgressPercentageFontSize, string[] nextMonthProgressWidth,
                                                   string[] nextMonthProgressMaxWidth, string[] nextMonthProgressCompleteOpacity)
    {
        try
        {
            string idNumber = "2345";
            var newEntry = new Entry {
                id = idNumber,
                UrgentTaskValue = [],
                UrgentTeamImage1 = [],
                UrgentTeamImage2 = [],
                UrgentTeamImage3 = [],
                UrgentTeamImage4 = [],
                UrgentTeamImage5 = [],
                UrgentTeamImage6 = [],
                UrgentTeamImage7 = [],
                UrgentTeamImage8 = [],
                UrgentStatusTextContent = [],
                UrgentStatusColor = [],
                UrgentDescriptionTextContent = [],
                UrgentProgressPercentage = [],
                UrgentProgressPercentageParsed = [],
                UrgentProgressPercentageFontSize = [],
                UrgentProgressPercentageBackground = [],
                UrgentProgressWidth = [],
                UrgentProgressMaxWidth = [],
                UrgentProgressCompleteOpacity = [],
                ThisMonthTaskValue = [],
                ThisMonthTeamImage1 = [],
                ThisMonthTeamImage2 = [],
                ThisMonthTeamImage3 = [],
                ThisMonthTeamImage4 = [],
                ThisMonthTeamImage5 = [],
                ThisMonthTeamImage6 = [],
                ThisMonthTeamImage7 = [],
                ThisMonthTeamImage8 = [],
                ThisMonthStatusTextContent = [],
                ThisMonthStatusColor = [],
                ThisMonthDescriptionTextContent = [],
                ThisMonthProgressPercentage = [],
                ThisMonthProgressPercentageParsed = [],
                ThisMonthProgressPercentageFontSize = [],
                ThisMonthProgressPercentageBackground = [],
                ThisMonthProgressWidth = [],
                ThisMonthProgressMaxWidth = [],
                ThisMonthProgressCompleteOpacity = [],
                NextMonthTaskValue = [],
                NextMonthTeamImage1 = [],
                NextMonthTeamImage2 = [],
                NextMonthTeamImage3 = [],
                NextMonthTeamImage4 = [],
                NextMonthTeamImage5 = [],
                NextMonthTeamImage6 = [],
                NextMonthTeamImage7 = [],
                NextMonthTeamImage8 = [],
                NextMonthStatusTextContent = [],
                NextMonthStatusColor = [],
                NextMonthDescriptionTextContent = [],
                NextMonthProgressPercentage = [],
                NextMonthProgressPercentageParsed = [],
                NextMonthProgressPercentageFontSize = [],
                NextMonthProgressPercentageBackground = [],
                NextMonthProgressWidth = [],
                NextMonthProgressMaxWidth = [],
                NextMonthProgressCompleteOpacity = []
            };
            foreach (var content in urgentTaskValue)
            {
                newEntry.UrgentTaskValue.Add(content);
            } 
            foreach (var content in urgentTeamImage1)
            {
                newEntry.UrgentTeamImage1.Add(content);
            } 
            foreach (var content in urgentTeamImage2)
            {
                newEntry.UrgentTeamImage2.Add(content);
            } 
            foreach (var content in urgentTeamImage3)
            {
                newEntry.UrgentTeamImage3.Add(content);
            } 
            foreach (var content in urgentTeamImage4)
            {
                newEntry.UrgentTeamImage4.Add(content);
            } 
            foreach (var content in urgentTeamImage5)
            {
                newEntry.UrgentTeamImage5.Add(content);
            } 
            foreach (var content in urgentTeamImage6)
            {
                newEntry.UrgentTeamImage6.Add(content);
            } 
            foreach (var content in urgentTeamImage7)
            {
                newEntry.UrgentTeamImage7.Add(content);
            } 
            foreach (var content in urgentTeamImage8)
            {
                newEntry.UrgentTeamImage8.Add(content);
            } 
            foreach (var content in urgentStatusTextContent)
            {
                newEntry.UrgentStatusTextContent.Add(content);
            } 
            foreach (var content in urgentStatusColor)
            {
                newEntry.UrgentStatusColor.Add(content);
            }
            foreach (var content in urgentDescriptionTextContent)
            {
                newEntry.UrgentDescriptionTextContent.Add(content);
            }
            foreach (var content in urgentProgressPercentage)
            {
                newEntry.UrgentProgressPercentage.Add(content);
            }
            foreach (var content in urgentProgressPercentageParsed)
            {
                newEntry.UrgentProgressPercentageParsed.Add(content);
            }
            foreach (var content in urgentProgressPercentageFontSize)
            {
                newEntry.UrgentProgressPercentageFontSize.Add(content);
            }
            foreach (var content in urgentProgressPercentageBackground)
            {
                newEntry.UrgentProgressPercentageBackground.Add(content);
            }
            foreach (var content in urgentProgressWidth)
            {
                newEntry.UrgentProgressWidth.Add(content);
            }
            foreach (var content in urgentProgressMaxWidth)
            {
                newEntry.UrgentProgressMaxWidth.Add(content);
            }
            foreach (var content in urgentProgressCompleteOpacity)
            {
                newEntry.UrgentProgressCompleteOpacity.Add(content);
            }
            foreach (var content in thisMonthTaskValue)
            {
                newEntry.ThisMonthTaskValue.Add(content);
            } 
            foreach (var content in thisMonthTeamImage1)
            {
                newEntry.ThisMonthTeamImage1.Add(content);
            } 
            foreach (var content in thisMonthTeamImage2)
            {
                newEntry.ThisMonthTeamImage2.Add(content);
            } 
            foreach (var content in thisMonthTeamImage3)
            {
                newEntry.ThisMonthTeamImage3.Add(content);
            } 
            foreach (var content in thisMonthTeamImage4)
            {
                newEntry.ThisMonthTeamImage4.Add(content);
            } 
            foreach (var content in thisMonthTeamImage5)
            {
                newEntry.ThisMonthTeamImage5.Add(content);
            } 
            foreach (var content in thisMonthTeamImage6)
            {
                newEntry.ThisMonthTeamImage6.Add(content);
            } 
            foreach (var content in thisMonthTeamImage7)
            {
                newEntry.ThisMonthTeamImage7.Add(content);
            } 
            foreach (var content in thisMonthTeamImage8)
            {
                newEntry.ThisMonthTeamImage8.Add(content);
            } 
            foreach (var content in thisMonthStatusTextContent)
            {
                newEntry.ThisMonthStatusTextContent.Add(content);
            } 
            foreach (var content in thisMonthStatusColor)
            {
                newEntry.ThisMonthStatusColor.Add(content);
            }
            foreach (var content in thisMonthDescriptionTextContent)
            {
                newEntry.ThisMonthDescriptionTextContent.Add(content);
            }
            foreach (var content in thisMonthProgressPercentage)
            {
                newEntry.ThisMonthProgressPercentage.Add(content);
            }
            foreach (var content in thisMonthProgressPercentageParsed)
            {
                newEntry.ThisMonthProgressPercentageParsed.Add(content);
            }
            foreach (var content in thisMonthProgressPercentageFontSize)
            {
                newEntry.ThisMonthProgressPercentageFontSize.Add(content);
            }
            foreach (var content in thisMonthProgressPercentageBackground)
            {
                newEntry.ThisMonthProgressPercentageBackground.Add(content);
            }
            foreach (var content in thisMonthProgressWidth)
            {
                newEntry.ThisMonthProgressWidth.Add(content);
            }
            foreach (var content in thisMonthProgressMaxWidth)
            {
                newEntry.ThisMonthProgressMaxWidth.Add(content);
            }
            foreach (var content in thisMonthProgressCompleteOpacity)
            {
                newEntry.ThisMonthProgressCompleteOpacity.Add(content);
            }
            foreach (var content in nextMonthTaskValue)
            {
                newEntry.NextMonthTaskValue.Add(content);
            } 
            foreach (var content in nextMonthTeamImage1)
            {
                newEntry.NextMonthTeamImage1.Add(content);
            } 
            foreach (var content in nextMonthTeamImage2)
            {
                newEntry.NextMonthTeamImage2.Add(content);
            } 
            foreach (var content in nextMonthTeamImage3)
            {
                newEntry.NextMonthTeamImage3.Add(content);
            } 
            foreach (var content in nextMonthTeamImage4)
            {
                newEntry.NextMonthTeamImage4.Add(content);
            } 
            foreach (var content in nextMonthTeamImage5)
            {
                newEntry.NextMonthTeamImage5.Add(content);
            } 
            foreach (var content in nextMonthTeamImage6)
            {
                newEntry.NextMonthTeamImage6.Add(content);
            } 
            foreach (var content in nextMonthTeamImage7)
            {
                newEntry.NextMonthTeamImage7.Add(content);
            } 
            foreach (var content in nextMonthTeamImage8)
            {
                newEntry.NextMonthTeamImage8.Add(content);
            } 
            foreach (var content in nextMonthStatusTextContent)
            {
                newEntry.NextMonthStatusTextContent.Add(content);
            } 
            foreach (var content in nextMonthStatusColor)
            {
                 newEntry.NextMonthStatusColor.Add(content);
            }
            foreach (var content in nextMonthDescriptionTextContent)
            {
                newEntry.NextMonthDescriptionTextContent.Add(content);
            }
            foreach (var content in nextMonthProgressPercentage)
            {
                newEntry.NextMonthProgressPercentage.Add(content);
            }
            foreach (var content in nextMonthProgressPercentageParsed)
            {
                newEntry.NextMonthProgressPercentageParsed.Add(content);
            }
            foreach (var content in nextMonthProgressPercentageFontSize)
            {
                newEntry.NextMonthProgressPercentageFontSize.Add(content);
            }
            foreach (var content in nextMonthProgressPercentageBackground)
            {
                newEntry.NextMonthProgressPercentageBackground.Add(content);
            }
            foreach (var content in nextMonthProgressWidth)
            {
                newEntry.NextMonthProgressWidth.Add(content);
            }
            foreach (var content in nextMonthProgressMaxWidth)
            {
                newEntry.NextMonthProgressMaxWidth.Add(content);
            }
            foreach (var content in nextMonthProgressCompleteOpacity)
            {
                newEntry.NextMonthProgressCompleteOpacity.Add(content);
            }
            ItemResponse<Entry> entry = await _container.ReplaceItemAsync(newEntry, newEntry.id, new PartitionKey(newEntry.id));
            return new OkResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new StatusCodeResult(500);
        }
    }
}