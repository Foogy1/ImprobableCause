# Improbable Cause
##**Github instructions:**##

-I would download a GUI to help simplify the process and avoid using command line, I highly recommend https://www.sourcetreeapp.com.
- Always pull before you start editing to avoid merge conflicts.
- DO NOT CHANGE PROJECT SETTINGS (ADDING SCENES, ETC.) WITHOUT INFORMING OTHERS AS THIS WILL CAUSE BAD MERGE CONFLICTS
 - (IE if you change project settings, revert them back to the way they were before you push.
  Please write useful commit messages, if we need to revert code it's hard to figure out where to revert to without good commit messages.
    - One sentence saying what functionality you added or changed.
 - If you have a merge conflict that you don't understand how to fix, **please message me!** You don't want to end up overwriting code as it's a pain to fix.
    
    
  ## Style ##
   - Please comment with block comments what each class after the class decleration. 
   - **Use camelcase** (i.e getPointer() instead of GET_PoinTEr() -> functions should start with a lower case and each additional word should be capitalized)
   **Classes should be Capitalized** (I.E AnchorPoints)
   - Please comment your code when it's not very obvious to other programmers what a function or variable does.
   - If a variable is public, please mark it with a **tooltip** (this allows others to see what changing a variable does in the Unity inspector).
   - On that note, **DO NOT make variables public unless it's useful to change them at runtime**.
   
   *Also, please download codeMaid*
    - **Instructions** (make sure to save first): 
      In visual studio, go to Tools -> Extensions and Updates -> Online -> search CodeMaid -> Install
      **Before pushing your code, clean your code with codemaid!!**
