let UnityPath =
    if isUnix then @"/Applications/Unity/Unity.app/Contents/MacOS/Unity" else @"C:\Program Files\Unity5.3.4f1\Editor\Unity.exe"
	
let Unity args =
    let fullPath = Path.GetFullPath(".")
    let result = Shell.Exec(UnityPath, "-quit -batchmode -logFile -projectPath \"" + fullPath + "\" " + args)
    if result < 0 then failwithf "Unity exited with error %d" result