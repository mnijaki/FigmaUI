using UnityEngine;

namespace MN
{
    public class README : MonoBehaviour
    {
        /* Here are some details about the project.
           
           Project consist of two scenes:
			- One called "Mock" (this is just a mock scene to show how the UI would look like in the game)
			- FigmaUI scene (this is the actual scene for purposes of the task).
			- Project was created in 3 days.
           
           I Created simple MVC framework for this project.
           I was thinking of using Zenject for DI but I decided to use my own DI framework 
           (think it would be overkill to use Zenject for this project).
           
           A lot of UI elements in hierarchy still needs to be optimized. 
           Eg:
            - splitting timer into two canvases so it will not dirty the whole UI.
			- Turning off raycast target on all elements that don't need it.
			- Turning off canvas group on all elements that don't need it
			- Adding sprite atlasing.  
			- Replace some of the Images(gradient)  with simpler grayscale images (so the can be colored in runtime).
			- Replace some of the Images with simple shapes (so the can be colored in runtime).
			- Removing all unused components and sprites.
			- Some of the assets settings needs to be optimized (eg. texture compression, sprite packing, etc)
			
		  As for the Code:
			- MVC architecture is implemented but it is not fully utilized.
			- I didn't had time to create some classes with actual data, but architecture supports Models.
			- I didn't had time to create some classes with actual data, but architecture supports Services.
			- I would refactor some of the code, leaning more towards loose coupling (eg using more Interfaces and etc)
			  This would make the code more testable.
			- I would like to add some base classes for common functionalities (eg. custom button)
			- Classes should be further divided into assemblies.
			
		  AS for task itself:
			- I wasn't sure what exactly should I implement in the task, so I implemented what I thought was needed.	
			- If I had more time I would implement more functionalities (eg. I would add some more buttons and etc)
			_ If needed I can implement more functionalities and also add tests.
        */
    }
}
