# unity-examples
Unity examples

## Unity + Git
Once we have setup git and lfs we should place all large files in the Assets/BigFiles subdirectory. That way they will all be automatically added to git-lfs.
 
### Setup: Once per computer
   
    brew install git-lfs
    git lfs install
    git lfs install --system

### Setup: Once per Project

    
### Setup: Once per Repository
You can either clone this repo, or do the following setup.

If you create from github.com and choose Unity it autogenerates a [.gitignore file](https://github.com/github/gitignore/blob/master/Unity.gitignore), but I changed all Unity folders to be relative paths:

    **/[Ll]ibrary/
    **/[Tt]emp/
    **/[Oo]bj/
    **/[Bb]uild/
    **/[Bb]uilds/
    **/Assets/AssetStoreTools*

The following `git lfs` commands generate lines in .gitattributes

    git lfs track "**/Assets/BigFiles/**/*"
    git lfs track "*.psd"
    git lfs track "*.mp3"
    git lfs track "*.wav"
    git lfs track "*.prefab"
    git lfs track "*.fbx"
    git lfs track "*.xcf"      

Optional, you should add to your .git/config file the following to have smarter merging using Unity's merge tool

[merge]
	tool = unityyamlmerge

[mergetool "unityyamlmerge"]
	trustExitCode = false
	cmd = '/Applications/Unity/Unity.app/Contents/Tools/UnityYAMLMerge' merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"
  
You will need to update cmd to point to the correct location for your OS. Usually `/Applications/Unity/Unity.app/Contents/Tools/UnityYAMLMerge` on Mac and `C:\Program Files (x86)\Unity\Editor\Data\Tools\UnityYAMLMerge.exe` on Windows. More info at [SmartMerge](https://docs.unity3d.com/Manual/SmartMerge.html)
  
### References
   * [git file matching](https://github.com/git-lfs/git-lfs/issues/986)
   * <http://en.joysword.com/posts/2016/03/setting_up_github_for_unity_projects/>
   * <http://stackoverflow.com/questions/36109307/use-unity-with-git-lfs>
   * <https://github.com/git-lfs/git-lfs/issues/282>
