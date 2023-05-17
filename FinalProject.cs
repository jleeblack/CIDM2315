using System.IO;

namespace FinalProject;
class Program
{
    static void Main(string[] args){
        Console.WriteLine("-----CIDM2315 Final Project: Justin Black------");
        Console.WriteLine("------------Welcome to Buff Hotel--------------");
        LoadData();//Loads room/customer data from roomData.txt file upon login
        Console.Write("--> Please input username\n");
        string username = Console.ReadLine();
        Console.Write("--> Please input password\n");
        string password = Console.ReadLine();
        bool isAdmin= adminUsers.TryGetValue(username, out string adminPassword) && adminPassword==password;
        /*I wanted to add the ability to clear all stored data with a single keypress vs having to manually delete individual rooms while conducting debugging and testing.
        I felt it would be a pretty risky option to have in the general menu for a normal employee, so I decided to create an admin(manager) specific menu with the clear all option
        and added the ability to assign accounts as admin vs normal accounts.*/

        if (!users.TryGetValue(username, out string storedPassword) || storedPassword!=password){//originally used ContainsKey but switched to TryGetValue for improved efficiency
            Console.WriteLine("\n--> Wrong Username/Password");//https://stackoverflow.com/questions/9382681/what-is-more-efficient-dictionary-trygetvalue-or-containskeyitem
            return;
        }
        Console.WriteLine("\n--> Login Successful.");
        
        while (true){
            Console.WriteLine();
            Console.WriteLine("***********************");
            Console.WriteLine("**     MAIN MENU     **");
            Console.WriteLine("***********************");
            Console.WriteLine($"** Hello User: {username} **");
            Console.WriteLine("***********************");
            Console.WriteLine("--> Please select:");
            Console.WriteLine("1. Show Available Room");
            Console.WriteLine("2. Check-In");
            Console.WriteLine("3. Show Reserved Room");
            Console.WriteLine("4. Check-Out");
            Console.WriteLine("5. Admin Menu");
            Console.WriteLine("6. Log Out");
            Console.WriteLine("***********************");
            Console.WriteLine("Type MAIN to return to this menu at any time.");

            string input = Console.ReadLine();
            float parsedOption;
            if (!float.TryParse(input, out parsedOption) || parsedOption!= (int)parsedOption){
                Console.WriteLine("\nInvalid Entry - Please enter a valid option number to continue.");
                continue;
            }

            int option = (int)parsedOption;
            switch (option){
                case 1:
                ShowAvailableRooms();
                break;

                case 2:
                CheckIn();
                break;

                case 3:
                ShowReservedRooms();
                break;

                case 4:
                CheckOut();
                break;

                case 5:
                if (isAdmin){//Ensures only admin account has access to admin functions within Admin menu
                    AdminMenu();
                }
                else{
                    Console.WriteLine("Access Denied - You must be a manager to enter this menu.");//if not admin
                }
                break;

                case 6:
                SaveData();//Saves data to roomData.txt file upon logging out.
                Console.WriteLine("\n-->You have logged out.");
                return;

                default:
                Console.WriteLine("\nInvalid option. Please try again.");
                break;
            }
        }
    }
    static void ShowAvailableRooms(){
        Console.WriteLine("\n*******  Vacant Rooms  *******");
        int availableRoomCount=0;

        foreach (var room in roomList){
            if (room.IsAvailable){
                Console.WriteLine($"+ Room Number: {room.RoomNumber}; Capacity: {room.Capacity}");
                availableRoomCount++;
            }
        }
        Console.WriteLine($"------Number of Available Rooms: {availableRoomCount}------\n");
    }
    static void CheckIn(){
        int numberOfPeople;
        int roomNumber;
        while(true){
            Console.Write("--> Input Number of People:\n");
            string input = Console.ReadLine();
            if (MainMenu(input)) return;
            if (int.TryParse(input, out numberOfPeople)){
                break;
            }
            Console.WriteLine("Invalid Entry - Please enter the correct number of guests.");
        }
        List<Room> matchedRooms = new List<Room>();

        foreach(var room in roomList){
            if (room.IsAvailable&&room.Capacity>= numberOfPeople){
                matchedRooms.Add(room);
            }
        }
        Console.WriteLine("------Available Rooms------");
        foreach (var room in matchedRooms){
            Console.WriteLine($"+ Room Number: {room.RoomNumber};Capacity: {room.Capacity}");
        }
        if (matchedRooms.Count== 0){
            Console.WriteLine($"0 rooms currently available");
            Console.WriteLine("--> No suitable rooms available at this time.");
            return;
        }
        else{
            Console.WriteLine($"--> {matchedRooms.Count} rooms currently available.");
        }
        while(true){
            Console.Write("\n--> Input Room Number:\n");
            string input = Console.ReadLine();
            if (MainMenu(input)) return;
            if (int.TryParse(input, out roomNumber)&& matchedRooms.Any(room=>room.RoomNumber==roomNumber)){
                break;
            }
            Console.WriteLine("Invalid entry - Please enter a valid room number.");
        }
        Room selectedRoom = matchedRooms.Find(room=>room.RoomNumber==roomNumber);

        if (selectedRoom==null){
            Console.WriteLine("--> Invalid room number.");
            return;
        }
        Console.Write("--> Input Customer Name:\n");
        selectedRoom.CustomerName = Console.ReadLine();

        Console.Write("--> Input Customer Email:\n");
        selectedRoom.CustomerEmail = Console.ReadLine();
        
        Console.WriteLine();
        Console.WriteLine($"--> Check-in successful! Customer is assigned to Room {selectedRoom.RoomNumber}");
        Console.WriteLine();
    }
    static void ShowReservedRooms(){
        Console.WriteLine("------Reserved Rooms------");
        int reservedRoomCount= 0;
        foreach(var room in roomList){
            if(!room.IsAvailable){
                Console.WriteLine($"+ Room {room.RoomNumber}: Customer: {room.CustomerName};");
                reservedRoomCount++;
            }
        }
        if (reservedRoomCount== 0){
            Console.WriteLine("No rooms are currently reserved.");
        }
    }
    static void CheckOut(){
        int roomNumber;
        Room selectedRoom;
        while(true){
            Console.WriteLine("--> Input Room Number:");
            string input= Console.ReadLine();
            if (MainMenu(input)) return;
            if (int.TryParse(input, out roomNumber)){
                selectedRoom = roomList.Find(room=> room.RoomNumber==roomNumber);
                if (selectedRoom != null){
                    if (!selectedRoom.IsAvailable){
                        break;
                    } else {
                        Console.WriteLine("--> Could not find customer record of this room.");
                    }
                } else {
                    Console.WriteLine("Invalid Entry - Please enter a valid room number.");
                }
            } else {
                Console.WriteLine("Invalid Entry - Please enter a valid room number.");
            }
        }
        Console.WriteLine($"Customer: {selectedRoom.CustomerName}");
        Console.WriteLine("Confirm check-out: Enter Y for YES or N for NO:\n");
        char confirmation= Console.ReadKey().KeyChar;
        Console.WriteLine();

        if (char.ToUpper(confirmation)== 'Y'){
            selectedRoom.CustomerName= null;
            selectedRoom.CustomerEmail= null;
            Console.WriteLine("--> Checked-Out Successfully");
            ShowReservedRooms();
        }
        else{
            Console.WriteLine("--> Check-out cancelled.");
        }
    }
    static bool MainMenu(string input){//used to revert back to main menu
        if (input.ToLower() == "main"){
            return true;
        }
        return false;
    }

    static List<Room> roomList = new List<Room>{
        new Room(101,2),
        new Room(102,2),
        new Room(103,2),
        new Room(104,2),
        new Room(105,2),
        new Room(106,3),
        new Room(107,3),
        new Room(108,3),
        new Room(109,3),
        new Room(110,4)
    };

    static void LoadData(){
        if (File.Exists(roomData)){//creates file roomData if doesnt already exist. file contains room data from save file
            roomList.Clear();
            string[] lines = File.ReadAllLines(roomData);
            foreach (string line in lines){
                string[] data= line.Split(';');
                int roomNumber= int.Parse(data[0]);
                int capacity= int.Parse(data[1]);
                string customerName= data[2] == "null" ? null:data[2];
                string customerEmail= data[3] == "null" ? null:data[3];
                roomList.Add(new Room(roomNumber, capacity, customerName, customerEmail));
            }
        }
    }

    static void SaveData(){//saves the room data so it will still be there at log-off and on multiple user accounts
        List<string> lines = new List<string>();
        foreach (var room in roomList){
            string customerName = room.CustomerName == null ? "null":room.CustomerName;
            string customerEmail = room.CustomerEmail == null ? "null":room.CustomerEmail;
            lines.Add($"{room.RoomNumber};{room.Capacity};{customerName};{customerEmail}");
        }
        File.WriteAllLines(roomData,lines);
    }

    static void ClearData(){//use to quickly clear all data from mainmenu - this is protected via admin only sub-menu
        foreach (var room in roomList){
            room.CustomerName=null;
            room.CustomerEmail=null;
        }
        SaveData();
        Console.WriteLine("Saved data has been cleared.");
    }

    static void Debug(){//used this to fix an early error of rooms not populating correctly, isnt currently needed
        Console.WriteLine($"Number of rooms in roomList: {roomList.Count}");
    }

    static void AdminMenu(){//added an Admin menu to ensure clear all was protected
        while (true){
            Console.WriteLine();
            Console.WriteLine("**************************");
            Console.WriteLine("**      ADMIN MENU      **");
            Console.WriteLine("**************************");
            Console.WriteLine("--> Please select:");
            Console.WriteLine("1. Clear All Data");
            Console.WriteLine("2. Debug");
            Console.WriteLine("3. Return to Main Menu");
            Console.WriteLine("**************************");

            string input = Console.ReadLine();
            float parsedOption;
            if (!float.TryParse(input, out parsedOption) || parsedOption != (int)parsedOption){
                Console.WriteLine("\nInvalid Entry - Please enter a valid option number.");
                continue;
            }
            int option= (int)parsedOption;
            switch(option){
                case 1:
                ClearData();
                break;

                case 2:
                Debug();
                break;
            
                case 3:
                return;

                default:
                Console.WriteLine("\nInvalid option. Please try again.");
                break;
            }
        }
    }

    private static readonly Dictionary<string,string> users= new Dictionary<string,string>{//opted to create user dict vs hardcoded user in main once I decided to create multiple accts + admin accts
        {"alice","alice123"},
        {"justin","black"},
    };

    private static readonly Dictionary<string,string> adminUsers= new Dictionary<string,string>{//defined admin accounts which can access admin sub-menu
        {"alice","alice123"},
    };
    
    private static string roomData = "roomData.txt";//reads data from roomData save file.
}
class Room{
    public int RoomNumber{get;set;}
    public int Capacity{get;set;}
    public string CustomerName{get;set;}
    public string CustomerEmail{get;set;}
    public bool IsAvailable => string.IsNullOrEmpty(CustomerName);
    public Room(int roomNumber, int capacity, string customerName= null, string customerEmail= null){
        RoomNumber=roomNumber;
        Capacity=capacity;
        CustomerName=customerName;
        CustomerEmail=customerEmail;
    }
}