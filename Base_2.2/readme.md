### 建立專案
```
	dotnet new mvc
```

### 啟動執行
```
    dotnet run
```

### wwwroot
    為了避免每個專案檔都 重覆 wwwroot , 所以採用如下方法
    1.使用 link dir 的技術,把 wwwrot 的目錄是以連結方式建立
    2.wwwrot 另外建立一個分枝儲存 