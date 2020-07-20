# Navigation 1 - Practical Work

Navigation work at classes of *Vrtual Reality and Interaction*, (second part [here](https://github.com/Arnaud58/navigation-2))

The subject of the work is below :

## 1 Introduction
You will work with two scenes in the hierarchy. A 3D scene already built (for example by importing: [village.unitypackage](https://www.fil.univ-lille1.fr/~aubert/rvi/village.unitypackage)) and your own scene in which you will include everything necessary for navigation and interaction. Only the latter will have to be rendered (export of the scene as a unity package).

> Question 1: Create 2 cameras and a UI with 2 buttons to activate one or the other camera. 
Test.

## 2 First-Person
> Question 2. For the first camera, create a script that allows "First-Person" navigation (modification of the camera transform):

'q'/'d' : allows to make a step to the left or to the right (action called "strafe"). Take into account Time.deltaTime to adjust the speed.
the X axis of the mouse allows to turn the torso left or right.
note that you have to lock the mouse by Cursor.lockState = CursorLockMode.Locked; to have an infinite movement but make sure to unlock by a switch (press "l" for lock/unlock).
the Y-axis of the mouse allows you to move your head up/down.
z'/'s': allows to move forward/backward in the direction of the torso (attention: not in the direction of the eyes).
Question 3. Limit the lift/lower rotation so as not to exceed -90 and 90 degrees.

> Question 4: Include a jump on the space key. Use a coroutine to animate the jump (i.e. 2 successive loops to increase then decrease a height).

> Question 5: Include a "lean" on the 'a' and 'e' keys: this means "tilting" the head to the left or to the right (corresponds to the roll).

> Question 6. Make sure that everything is coherent and the movements are intuitive. The movements should be "nervous" enough to navigate with ease.

> Question 7. Make a switch on the 'f' key so that 'z'/'s' moves the camera in the gaze direction instead of the torso (navigation often called "free look").

> Question 8. With Physics.Raycast, forbid movement if an object is nearby (simplistic collision with the scene).

## 3 Pointing navigation
> Question 9: Code in the second camera by using only the orientation of the point of view with the mouse (torso/view rotation).

> Question 10: You want the mouse pointer to appear when you left-click (the mouse movement no longer influences the direction of the camera): you switch to "pointing" mode. When we click again, we switch back to the view orientation with the mouse movement: code this switch.

> Question 11: Make sure that the torso is oriented towards the direction clicked in pointing mode. The difficulty lies in the consistency of your representation of the orientation for the camera: you must only influence the orientation of the torso. Vector3.projectOnPlane, Vector3.Angle, Vector3.Dot, Vector3.Cross, etc. can help.

> Question 12: In pointing mode: if you click, the torso is oriented to the target point with the mouse (previous question). If we hold the click and move the mouse down, we must move closer to the target point (drag and go action). This only makes sense if the target point is an intersection with the scene. Code this principle (ScreenPointToRay and Physics.Raycast can help).

> Question 13. In pointing mode: if you hold the click and move the mouse left/right, you orbit around the target point (if there is an intersection of the target point with the scene).