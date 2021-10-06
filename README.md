# Gold Badge Challenges

**By Adam Sadler**

This is a collection of console applications I have completed in order to earn my Gold Badge in Eleven Fifty Academy's Software Development course.

Below is a list of the applications, along with a brief description.

## List of Applications
- **Challege 1: Cafe** In this challenge, the class was tasked to create a console application to all a manager of a cafe to create new menu items, delete menu items, and view all menu items. Each menu item has a number, a name, a description, a list of ingredients, and a price. For this application, I created a menu class, as well as an ingredient class.
- **Challege 2: Claims** In this challenge, we used a queue to manage claims for an insurance company. The application needed to allow the user to create a new claim, process the next claim in the queue, and see all claims currently in the queue. I decided to do something a little extra in this challenge by preventing the user to enter an ID for a new claim that matched if that ID was already in use. To do this, I used the following code within the `CreateNewClaim()` method:
```
foreach(Claim claim in claimQueue)
{
    if(newClaim.ClaimID == claim.ClaimID)
    {
        bool duplicateId = true;

        while(duplicateId)
        {
            Console.WriteLine("This ID is already in use. Please enter a valid ID for this claim:");
            newClaim.ClaimID = Int32.Parse(Console.ReadLine());

            if(newClaim.ClaimID != claim.ClaimID)
            {
                duplicateId = false;
            }
        }
    }
}
```
- **Challenge 3: Badges** In this challenge, we needed to use a dictionary to manage employee badge information. This challenge was a bit of a learning process for me as it was my first time working with dictionaries. I struggled for a bit to find the best way to access a list of rooms available to a specific badge before coming up with the following `GetValuesByKey(int id)` method:
```
public List<string> GetValuesByKey(int id)
{
    foreach (var badge in _badges)
    {
        int badgeId = badge.Key;
        List<string> doors = badge.Value;

        if (badgeId == id)
        {
            return doors;
        }
    }
    return null;
}
```
- **Challenge 4: Company Outings** In this challenge, the goal was to create an application where the user could create new company outings, veiw all current company outings, get the total cost of all company outings, and display the total cost of company outings by type. To handle the type of event for each outing, I used an enum to store and access the 4 types of outings. This made it possible to total the cost of each type of outing individually. 
- **Challenge 5: Greeting** In this challenge, we had to create a database of current, past, and potential customers along with a sepcific email greeting associated with each of those customer types. As with the previous challenge, I used a enum for the 3 customer types to easily identify them in the application. The big challenge for me in this one was figuring out how to sort the list of customers by their last name property. After some trial and error, as well as a bit of research, I came up with this solution to sort the list:
```
var sortedList = from customer in allCustomers orderby customer.LastName ascending select customer;
```