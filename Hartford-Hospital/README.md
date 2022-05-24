# [Latest Version of Construct 3 File](https://github.com/SenLongYu/Past-Projects/blob/main/Hartford-Hospital/5_10_22.c3p)
1. Use the file 5_10_22.c3p as the latest version of the game 

# [Instructions To Get You Started](https://youtu.be/gxqEbNHuPws)
# [Lightning Video](https://www.youtube.com/watch?v=nE9T8NdhKAA)

# Hartford Hospital Game Development Team 
Documentation on the Hartford Hospital game development project.

# Hardware Dependencies
The hardware used to replicate our work should fulfil the system requirements outlined under Software Dependencies: System Requirements in the following section.  

# Software Dependencies
Software: Construct 3 - Game Making Software 
For more details on the features of Construct 3, please visit [their website](https://www.construct.net/en/make-games/games-editor). Construct 3 can be used anytime, anywhere and run in the browser. See below for system requirements. 


System requirements: 
  1. Internet connection (to load Construct 3 for the first time) 
  2. Supported Browsers (Construct 3 should run on any modern browser.) 
  3. Supported Operating System ( Construct 3 should run on any system with a modern browser.)
  4. WebGL support ( Almost all modern devices support WebGL which is a modern high-performance graphics technology for browsers.)

**For the purpose of this project, we recommend running Construct 3 in the browser of a modern computer and save periodically. This is recommended in order to avoid possible crashes etc. 

For additional details and/or exceptions please visit their page of [System Requirements](https://www.construct.net/en/make-games/manuals/construct-3/getting-started/system-requirements)  

# Tips to Replicate Work 

**_Installation of Software_**

Get Construct [here](https://www.microsoft.com/en-us/p/construct-3/9nbz6cp2p37p?activetab=pivot:overviewtab) 

OR

Use in Browser : go to their [website](https://www.construct.net/en)

  go to Launch Construct 3 --> Launch the Guided Tour 
  
![unknown](https://user-images.githubusercontent.com/89117761/145734173-13323dd8-1a3a-4586-8681-51a3c74e8c1a.png)
  
  Take tour or skip. We recommend taking the tour. 
  
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
**_Create a New Account_** 

Although logging in to the team's existing account may be referenced, please create a new account. The subscription and account used by this year's student development team will be canceled as of 5/11/22. Creating an account is easy and mostly intuitive. This is important and necessary for creating larger projects and exporting projects to iOS etc. 

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

**_Replicating Work and Creating New Functionality_**

Please become familiar with Construct 3 as a tool through the [instrcutional video](https://youtu.be/x-McOPyudho). Also read relavent parts of the [Construct 3 Manual](https://www.construct.net/en/make-games/manuals/construct-3). During replication, possible improvements and while creating new functionality, Construct 3 documentation will be the most helpful tool.

In addition to their documentation, you also have 
1. the [most recent project](https://github.com/UAlbany-ECE-Design-Lab/Hartford-Hospital/blob/main/5_10_22.c3p) (use [this video](https://youtu.be/gxqEbNHuPws) to help you open the project.
2. a [document](https://github.com/UAlbany-ECE-Design-Lab/Hartford-Hospital/blob/main/Sprites.docx) with editable sprites. 
3. Please obtain zipped file from the professor titled "Relevant Material 5_10_22". If this is not obtained, please do not worry. It primarily contains folders with each layout organized with its perspective sprites (pictured below). The construct 3 file already has this content stored in the project.

![Picture6](https://user-images.githubusercontent.com/89117761/167987259-04833bab-157d-433d-a0ff-ac25e23c7eed.png)

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

**_Future Work_** 

Your goal is to implement the medium and hard level. These levels should introduce refilling medications and making dosage changes and titrations. Veiw this [paper prototype](https://github.com/UAlbany-ECE-Design-Lab/Hartford-Hospital/blob/main/Prototype.pdf) for our idea of what we imagine the levels can look. Meet with stakeholders to confirm these ideas or present new ideas. 

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Lastly, below are the fundamental concepts and features implemented in this project. 

**_Initial Set Up_** 

1. Below is the "Start Page" (tab at top) 
  * Open project
  * Upload project if you are using a new account or using Construct 3 as a Guest. 
  
![image](https://user-images.githubusercontent.com/89117761/145734282-5abef971-06eb-4253-a16f-382d3ddeea6c.png)


2. Make VeiwPort size and Layout Size the same (for the purpose of this project) 
    * size of iPad this project will be used on is 1024 x 768
       > This is subject to change. Using Contruct 3, the entire project can be scaled to fit change in size of the iPad tablet. 
Final screen should look like this: 

![image](https://user-images.githubusercontent.com/89117761/145734774-0cc5e6be-4eec-41d7-a406-dfba8fb61005.png)

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

**_Some Useful Terms to Know Before Editing_**

Layout: Essentially the Screen 

Layer: Layers to the screen. Each layer can have different objects on it. 

Event Sheet: Where you put the code ( can have a 1:1 or 1:many relationship with the layouts - will be more important in future implementation) 

Object: Basically things you put on the screen (or layer) to edit it such as words, color, images etc. 

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
**_Make Compatible with Touch Screen_** 

1. Insert Touch Input 
   * double click on screen to create a new object - OR - right click--> insert new object 
   * scroll down to tiled Background 

![image](https://user-images.githubusercontent.com/89117761/145735810-c7ed6f70-c554-462e-bfc4-56882f3fca92.png)

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


**_Edit Background_**

1. Insert New Object  
    * double click on screen to create a new object - OR - right click--> insert new object 
    * scroll down to tiled Background 
    
![unknown](https://user-images.githubusercontent.com/89117761/145734945-c17733d5-cf60-4097-a4fe-5f47347814ee.png)

click anywhere on screen to place object. 

2. Upload from Computer
    * Click on folder icon in top left corner to insert photo from computer 
    
![image](https://user-images.githubusercontent.com/89117761/145735491-f0beec0e-37bc-40b8-b199-42a3ff78ac77.png)

3. Set background to a single color
    * double click on screen to create a new object - OR - right click--> insert new object 
    * scroll down to tiled Background
    * click anywhere on screen to place object.
    * Use paint can icon to fill in box with chosen color
    
![image](https://user-images.githubusercontent.com/89117761/145735548-41b4042b-4c1f-4609-9fb5-67f4b84d9dfb.png)


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


**_Insert Sprite_**

1. Use Sprite to add Medbox, individual pills, buttons, gifs and other visuals" 
    * double click on screen to create a new object - OR - right click--> insert new object 
    * scroll down to Sprite -> insert
    * click anywhere on screen to place object.
    * upload image from computer as previously outlined. See Edit Background:Upload from Computer. 

![unknown](https://user-images.githubusercontent.com/89117761/145736470-2b1b081a-a942-4423-96ea-da248e61f691.png)


2. Make background of image transparent 
    * Use paint can icon and choose transparent "color" 
    * For more precise erasing of background, use eraser and change size as needed.
   
![image](https://user-images.githubusercontent.com/89117761/145736769-4a84db49-aafc-49cd-bf6f-4a2689f9e10f.png)

3. Add GIF and make background transparent 
(Note GIF will not have movement until implemented in Code. See Event Sheet 1: Click Animation)

    * Use paint can icon and choose transparent "color" 
    * For more precise erasing of background, use eraser and change size as needed.
    * this needs to be done for each of its frames 

![image](https://user-images.githubusercontent.com/89117761/145736848-752a00a5-9f3e-4191-a9c7-3ce84a578146.png)

4. Add frames to Sprite 
(Note this is used to imitate pills being added to compartment. See Event Sheet 1: Adding Pills )
    * create sprite 
    * add animation (right part of screen below) 
    * Edit frame of each animation 
(here: the "1 pill" animation has one frame in which it has one pill. This concept will be used for 2+ pills as well) 
 
![image](https://user-images.githubusercontent.com/89117761/145739514-c9e0e70c-e839-4119-900b-b92597ffc6ea.png)


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

**_Insert Button_**

1. Use Button and connect function to button
(See Event Sheet 1: Button Code)

    * double click on screen to create a new object - OR - right click--> insert new object 
    * scroll down to button -> insert
    * click anywhere on screen to place object

![unknown](https://user-images.githubusercontent.com/89117761/145736470-2b1b081a-a942-4423-96ea-da248e61f691.png)



--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


**_Insert Text_**

1. Add Text to Screen 
    * double click on screen to create a new object - OR - right click--> insert new object 
    * scroll down to Text -> insert
    * click anywhere on screen to place object

![image](https://user-images.githubusercontent.com/89117761/145737263-83d93753-29b4-457d-84c0-d68db075439b.png)

2. Edit Text on Screen 
    * double click on text box once placed 
    * Change properties of text (bottom left of screen)

![image](https://user-images.githubusercontent.com/89117761/145737234-abb9951f-8aa1-4d91-8e81-2ea4032d99e3.png)

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

**_Insert Sound and Music_**

1. In the Project bar on Construct 3, right click on sounds --> Import sounds. 

![Picture2](https://user-images.githubusercontent.com/89117761/167982810-7add5606-928e-4552-8e39-a29300b17adc.png)

2. Drag and drop downloaded file as prompted
3. Add sound to event sheet using appropriate conditions. 

![Picture4](https://user-images.githubusercontent.com/89117761/167983174-ed4cb062-e927-4bba-9a09-dab2b16f767c.png)

(This is the Start Screen's event sheet "esStartScreen") 

--------------------------------------------------------------------------------------------------------------------------------------------------
## Event Sheet 1 - Code Part 

This is how the even sheet looks before adding any events. This includes a brief description of what an event sheet is. 

![image](https://user-images.githubusercontent.com/89117761/145739893-c348fc04-9455-4af8-9ad3-cb9ade3b9d60.png)

**_Click Animation (or other animations)_**

1. This code outlines how to make the GIF animate. Use this concept for using GIFs in future implementations. 

    * add event --> add condition "System" --> add system condition "Every tick" (runs this action always) 
    * add action "Sprite for the GIF" --> add action for the GIF "Set animation"
    * next, type name of animation into quotations--> click done


![image](https://user-images.githubusercontent.com/89117761/145741600-eff8681e-0b10-41e9-a42e-f3981fc732f4.png)


**_Other_**

1. This code block allows transition from screen to screen  

    * add event --> add condition "touch" --> add touch condition as "On tap object"
    * add action "System" --> add action for the System "Go to layout (by name)" 
    * next, type name of layout into quotations--> click done

![image](https://user-images.githubusercontent.com/89117761/145741676-f150c6d1-6cc4-4d02-afb1-83648f97b23a.png)


These concept, outlined above, is used for the following events

![image](https://user-images.githubusercontent.com/89117761/145741821-c13b1cfe-767e-4b0a-8123-51ef5305ef99.png)

**_Adding Pills_** 

Follow this portion of the events to change number of pills in compartment from 0 pills to 1 pill

![image](https://user-images.githubusercontent.com/89117761/145742021-6a74c938-918a-4746-b60d-ccee2b39894f.png)

Alternative method has been implemented in the latest version of the project (5_10_22.cp3). This method is more efficient and uses less sprites. Please open the project and veiw "esFill_1IS". 

![Picture1](https://user-images.githubusercontent.com/89117761/167979622-49c4a5db-d7d0-4e2c-bcfe-555d28baa10b.png)

# Instructional Video

[Instructional Video](https://youtu.be/x-McOPyudho)

This video link above shows the steps necessary to set-up our Hello World environment and replicate
our work that has been completed (FALL 2021). This video also allows you to become familiar with the project and Construct 3. 

