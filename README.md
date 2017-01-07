# unity-examples
Unity examples

## Setup Unity with Git Version Control
Once we have setup git and lfs we should place all large files in the Assets/LargeFiles subdirectory. That way they will all be automatically added to git-lfs.

If you are using `Git Desktop`, and you have cloned this repository, then there is no additional setup you need to do. Although you could do the optional `SmartMerge` setup if you are actually doing a lot of collaboration.

If you are setting up command-line support, or setting up a new repository from scratch, ir setting up a new Unity Project, follow the appropriate instructions below:
 
### Setup: Once per Computer
   
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
You can either clone this repo, or do the following setup.

#### .gitignore
If you create from github.com and choose Unity it autogenerates a [.gitignore file](https://github.com/github/gitignore/blob/master/Unity.gitignore), but I changed all Unity folders to be relative paths:

    **/[Ll]ibrary/
    **/[Tt]emp/
    **/[Oo]bj/
    **/[Bb]uild/
    **/[Bb]uilds/
    **/Assets/AssetStoreTools*
    
Or just copy this repos .gitignore file to your repo.

#### git Large Files (git-lfs)
The following `git lfs` commands generate lines in .gitattributes. Or just copy this repo's `.gitattributes` file to your repo

    git lfs track "**/Assets/LargeFiles/**/*"
    git lfs track "*.psd"
    git lfs track "*.mp3"
    git lfs track "*.wav"
    git lfs track "*.prefab"
    git lfs track "*.fbx"
    git lfs track "*.xcf"      

#### Unity git / merging (SmartMerge)
Optional. You should add to your `.git/config` file the following to have smarter merging using Unity's merge tool, OS-X example below:

    [merge]
    	tool = unityyamlmerge

    [mergetool "unityyamlmerge"]
    	trustExitCode = false
    	cmd = '/Applications/Unity/Unity.app/Contents/Tools/UnityYAMLMerge' merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"
  
You will need to update cmd to point to the correct location for your OS. Usually `/Applications/Unity/Unity.app/Contents/Tools/UnityYAMLMerge` on Mac and `C:\Program Files (x86)\Unity\Editor\Data\Tools\UnityYAMLMerge.exe` on Windows. More info at [SmartMerge](https://docs.unity3d.com/Manual/SmartMerge.html)
  
### References
   * [Setting Up Github (and Git LFS) for Unity projects](http://en.joysword.com/posts/2016/03/setting_up_github_for_unity_projects/)
   * [git file matching](https://github.com/git-lfs/git-lfs/issues/986)
   * <http://stackoverflow.com/questions/36109307/use-unity-with-git-lfs>
   * <https://github.com/git-lfs/git-lfs/issues/282>
