# Gold Badge Challenges

**By Adam Sadler**

This is a collection of console applications I have completed in order to earn my Gold Badge in Eleven Fifty Academy's Software Development course.

Below is a list of the applications, along with a brief description.

## List of Applications
- **Challege 1: Cafe** In this challenge, the class was tasked to create a console application to all a manager of a cafe to create new menu items, delete menu items, and view all menu items. Each menu item has a number, a name, a description, a list of ingredients, and a price. For this application, I created a menu class, as well as an ingredient class.
- **Challege 2: Claims** In this challeng we used a queue to manage claims for an insurance company. The application needed to allow the user to create a new claim, process the next claim in the queue, and see all claims currently in the queue. I decided to do something a little extra in this challenge by preventing the user to enter an ID for a new claim that matched if that ID was already in use. To do this, I used the following code within the `CreateNewClaim()` method:
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
- **Challenge 3: Badges** In this challenge, we needed to use a dictionary to manage employee badge information. 