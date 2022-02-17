<!-- Running the Project -->

<div id="top">

Important!: Please install the icluaded SQL file "Promoit-Database-MySQL.sql" inside the local Database.                                                                          <br />
Please set it inside the file  "PromotItLibrary\Models\Configuration.cs".         <br />
Please run all the 4 projects:                                                    <br />
- PromotItFormApp           <br />
- PromoitTwitterAPI         <br />
- PromoitFunctions          <br />
- PromoitQueue              <br />

</div>


<!-- PROJECT LOGO -->
<br />
<div align="center">  
    <img src="https://www.upload.ee/image/13836004/LogoPromoit.png" alt="Logo" width="230" height="85">
    <img src="https://www.upload.ee/image/13836007/ZioNET-Logo_new_new-156x66.png" alt="Logo" width="120" height="45"> <br>
    <p>Project made by: Yaron Malul, Arthur Zarankin and Ariel Hillel.</p>
  </a>  
     <br />
</div>

<div align="left">
<p>(Navigate Here)<p/>
    </div>
<!-- TABLE OF CONTENTS -->

<!-- ABOUT THE PROJECT -->
## About The Project

<div align="center">
  <img src=https://www.upload.ee/image/13836041/promoit_demo.png alt="MainApp" width="670" height="330"> <br>
  <p align="center"> PromoIt? What is it?</br> 
PromoIt is a campaign-friendly application based on social media platforms, this application is still under development thus it
supports Twitter only.
In such a modern society, where the social media is the main core of the advertising world - we thought of a way to actually 
benefit the world, along with the users, by promoting non-profit campaigns through our application.
We are encouraging the younger generation to work for a better future, better society and better ideologies by giving them an option to earn products on participation in the program we built and offer.

</div>

<p align="right">(<a href="#top">back to top</a>)</p>


### Built With

* [.NET 6.0]
* [MySQL]
* [Azure Functions]
* [Twitter API]
* [Azure Queue Storage]

<p align="right">(<a href="#top">back to top</a>)</p>


<!-- GETTING STARTED -->
## Getting Started
### Registry
* REGISTRY <br>
This service is being used to register four different types of users. By the type of the user the system will associate the specific type into an individual database table. 
The registry panel was built using windows form, a new tab is being displayed with a selection out of four different roles, each role directs to a unique panel to navigate in, according to the role's features and needs. When the registration is proceed, the user automatically being moved to the login panel.

<strong> ProLobby Owner (Admin) </strong> <br>
This user manages the system. <br>
Registration Form: A new window-form with three fields: Full Name, Username and Password.<br>


<strong> Non-Profit Organization (Campaigns Creator) </strong> <br>
This user is the main core of the campaigns creation, represnting a non-profit organization.<br>
Registration Form: A new window-form with five fields: Organization Name, Username, Password, Website/URL and Email.<br>

<strong> Business Company Representative (Sponsor/Donor)</strong>  <br>
This user is a company that stands for campaigns and donate their goods in order to promote an agenda or just support them. This role is also the one sending the products to social-activists. <br>
Registration Form: A new window-form with three fields: Company Name, Company Username and Password.<br>

<strong> Social Activist (Promoter/Supporter) </strong> <br>
This role is the wind in our sails. It's main goal is supporting a campaign, or many, by posting tweets and showing a supportive agenda. By promoting campaigns, the social activists are earning dollars/points (A dollar for a tweet and another dollar for a re-tweet). So they can redeem the money and purchase products, from our application.<br>
Registration Form: A new window-form with six fields: Full Name, Twitter Username, Password, Email, Address and Phone Number.<br>

### Login
* LOGIN <br>
This service is being used to let registered users log in to the application. The login should be checking whether the fields match a registered user's information within it's table.<br>
If the user is indeed registered, a panel designed for the role (User's type) will be displayed and contain it's special features, considered the role is being signed in.
Otherwise, if there isn't a user exist, a pop-up notification should appear with a description of the error. <br>
<br>
<strong> ProLobby Owner (Admin) </strong> <br>
Dashboard: Within this role's panel, there are three buttons that represent different types of reports. Tweets, Users and Campaigns. 
Each button displays a data grid of the specific reported being clicked, it's also optional to save the logs of the reports in the main folder. <br><br>

<strong> Non-Profit Organization (Campaigns Creator) </strong> <br>
Dashboard: Within this role's panel, there is a button to create a new campaign, following the fields: Campaign Name, Hashtag and Website/URL (Landing page of the campaign).<br>
Data grid that is linked to the MySQL's campaigns table which is used to display the campaigns that already created by the SAME user, including a delete button for easeir control. <br>

<br>
<strong> Business Company Representative (Sponsor/Donor)</strong>  <br>
Dashboard: Within this role's panel, there are two data grids: Buyers List and Campaigns List. <br>
Buyers List: Including two columns: Buyer Name, name of the social activist who bought a product and Product Name, the name of the product that was purchased. This grid provides a button to send a product. <br>
By clicking on 'Send Product', a tweet is being posted on the main account and a message sent to the Social Activist's messages-panel. (Example below)<br>
<img src=https://www.upload.ee/image/13836247/tweetbcr.png alt="Tweet" width="560" height="150"> <br>
Campaigns List: Including two columns: Hashtag, the campaign's hashtag to provide so social-activists can refer to what they're posting and URL. Within this grid, there are two buttons, Products List - So a company can see what products were donated and Donate, so a company can donate products and support a campaign or mutual agenda, a company can donate to any campaign. <br><br>

<strong> Social Activist (Promoter/Supporter) </strong> <br>
Dashboard: In the social-activist's panel there are many features, Total Balance, Messages Panel and Data Grid.<br>
Total Balance: In this panel, the user can always watch and follow it's current balance.<br>
Messages Panel: In this panel, the user is getting all the notifications to - when buying, donating or a general message.<br>
Data Grid: This grid contains three columns, Hashtag, URL and Balance, they represent the campaign and it's currency by tweeting to it.<br>
All the campaigns that were created in our application would be visible for the social-activist, also, a buttom for 'Products List' which is responsible for the navigation between products that were donated, with a button to buy a product or a button to donate it back to the campaign it was bought from.

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- SERVICES -->
## Services
* **Campaigns Service**<br>
This service allows a Non-Profit Organization user to create a new campaign, delete a campaign and basically giving the user an easier control. <br>
Additionally, it should also gather and display a list of the created campaigns, made by the same user only! <br>

* **Products Service**<br>
This service provides a simple products management system. On-click, a Business Company user should have an option of creating a new product and assigning it to the campaign, moreover, the systems allows the user to inspect already donated products and list of created campaigns. <br>
_(Getting a list of products so a Social-Activist user could buy or alternatively donate from by achieving points/dollars when posting tweets and re-tweets in Twitter)_ <br>
**(In future this feature should be expanded into a bigger scale of social platforms)** <br>

* **Balance Service**<br>
This service updates the Social-Activist user's current balance, each time the system gets a notification from Twitter when both conditions were made, Hashtag and URL. A Social-Activist user will get a dollar per tweet when they post from their personal account and another dollar per re-tweet <br>

* **Twitter Service**<br>
The Twitter Service is provided by API, V1.1 ACCESS V2 ACCESS and OAuth 1.0a. When the authorization is granted, the service follows hashtags and URLs made by a Social-Activist user. <br>
When Tweet is posted by a Social-Activist, the service validates both hashtag and a website/URL, it will after synchronize the process with the Balance Service and by that it will keep the Social-Activist current balance updated. Each time a Tweet accomplishes the conditions of earnings, a notification should be next in the balance service queue. <br>

* **Purchase Service** <br>
This service works in full conjunction with the Balance Service, when a Social-Activist user holds sufficient dollars/points, the system gives the option of purchasing a new product from the given list or alternatively donate from it to the same campaign. <br> 
If the product was purchased or donated, the Social-Activist's balance should be set according to the product that was picked from the list and update the quantity, if a product was bought, it's quantity should be decreased by the amount purchased, although, if the products were donated, the quantity should not be changed due to the fact they donate it to the same campaign. <br><br>
Additionally, when a Social-Activist user buys or donates a product, a Business Company user gets a request to accept the purchase. When the process is done, a new tweet should  be posted from the system main Twitter account. <br>

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- USAGE EXAMPLES -->
## Usage

Use this space to show useful examples of how a project can be used. Additional screenshots, code examples and demos work well in this space. You may also link to more resources.

_For more examples, please refer to the [Documentation](https://example.com)_

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap

- [x][@Task List](https://github.com/users/w3arthur/projects/3)

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Yaron Malul - [@GitHub](https://github.com/YaronMalul) - melloulyar@gmail.com <br>
Ariel Hillel - [@GitHub](https://github.com/arielhillel) - arielhillel@gmail.com <br>
Arthur Zarankin - [@GitHub](https://github.com/w3arthur) - w3arthur@gmail.com

Project Link: [https://github.com/w3arthur/PromoIt](https://github.com/w3arthur/PromoIt)

<p align="right">(<a href="#top">back to top</a>)</p>
