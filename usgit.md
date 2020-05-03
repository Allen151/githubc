# git的使用  

- 查看仓库状态  
`$ git status` 查看仓库的状态，提示`no changes added to commit`表示有更新，还没加入仓库。相关的文件是红色。  

- 更新仓库的文件与提交新文件到仓库的命令一样  
```
$ git add/rm readme.txt   #更改了文件后要执行这个才能变成绿色，add添加文件，rm移除文件
$ git commit -m “描述”    #该命令将add或者rm的文件添加到本地仓库
```

- push文件到github  
`$ git push origin master `把本地master分支的最新修改推送至`GitHub`

- 将仓库的文件下载到本地  
`$ git clone git@github.com:allen151/gitskills.git`

- test branch