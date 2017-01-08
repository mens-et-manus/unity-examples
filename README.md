# unity-examples
Setup Unity with Git Version Control

## Summary
Once we have setup git and lfs we should place all large files in the Assets/LargeFiles subdirectory. That way they will all be automatically added to git-lfs.

If you are using `Git Desktop`, and you have cloned this repository, then there is no additional setup you need to do. Although you could do the optional `SmartMerge` setup if you are actually doing a lot of collaboration.

If you are setting up command-line support, or setting up a new repository from scratch, or setting up a new Unity Project, follow the appropriate instructions below:

### Setup: Once per Computer
This is for command-line support only. If you are using Github Desktop git-lfs is already installed. Instructions below assume OS-X and brew, for other OS see [git-lfs](https://git-lfs.github.com/)   
   
    brew install git-lfs
    git lfs install
    git lfs install --system

### Setup: Once per Unity Project
In your Unity project, verify:

in `Edit → Project Settings → Editor`:
 * Change Version Control Mode to `Visible Meta Files`
 * Change Asset Serialization Mode to `Force Text`
 
Then Save Scene and Project. These settings will make multi-user merging manageable.
    
### Setup: Once per Repository
You can either clone this repo, or do the following:

 * Copy the .gitignore file from this repo to yours
 * Copy the .gitattributes file from this repo to yours 
 
#### SmartMerge (Optional)
In order to make merging of Unity files easier, Unity provides a tool called SmartMerge. Since the path to the SmartMerge tool is OS dependent you need to add configuration to your `.git/config` file. That is your computer's repo specific config file. I appended the following to my config file (on OS-X):

    [merge]
    	tool = unityyamlmerge

    [mergetool "unityyamlmerge"]
    	trustExitCode = false
    	cmd = '/Applications/Unity/Unity.app/Contents/Tools/UnityYAMLMerge' merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"
  
You will need to update cmd to point to the correct location for your OS. Usually `/Applications/Unity/Unity.app/Contents/Tools/UnityYAMLMerge` on Mac and `C:\Program Files (x86)\Unity\Editor\Data\Tools\UnityYAMLMerge.exe` on Windows. More info at [SmartMerge](https://docs.unity3d.com/Manual/SmartMerge.html).
  
### References
   * [Setting Up Github (and Git LFS) for Unity projects](http://en.joysword.com/posts/2016/03/setting_up_github_for_unity_projects/)
   * [git file matching](https://github.com/git-lfs/git-lfs/issues/986)
   * <http://stackoverflow.com/questions/36109307/use-unity-with-git-lfs>
   * <https://github.com/git-lfs/git-lfs/issues/282>
