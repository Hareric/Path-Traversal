# 路径遍历

## 问题描述
给定有向节点图，其中包含起始点(StartNode)和普通节点(Node)；指定某节点，返回所有起始点到该节点的所有路径。

## 解决方案

 1. 构建节点图时，起始节点与普通节点分别存放。
 2. 使用深度优先遍历算法遍历指定两点之间的所有路径
 3. 重复调用获得所有顶点到指定点之间所有路径
 
## 算法描述
### 深度优先遍历算法
![深度优先遍历算法.gif][1]

## 代码说明
### **类：Node**
#### **函数：Node**
`Node(string name， Guid id， bool isStartNode = false)`

构造函数，通过参数实例化一个节点。

### **类：Edge**
#### **函数：Edge**
`Edge(Guid source， Guid target)`

构造函数，通过源点ID和节点ID，实例化连接两个节点的一条有向边。

### **类：Graph**
#### **函数：Graph**
`Graph()`

构造函数，实例化一个图，并对存储图的节点列表(NodeList)和边列表(EdgeList)进行初始化。

#### **函数：AddNode**
`void AddNode(Node node)`

给图添加新的节点，将传入的节点保存至图内的节点列表(NodeList)。

#### **函数：AddEdge**
`void AddEdge(Guid nodeSourceID， Guid nodeTargetID)`

给图添加新的节点连边，通过节点ID实例化一条有向边(Edge)并存入边列表(EdgeList)

#### **函数：GetAllPathBetweenTwoNode**
`List<List<Guid>> GetAllPathBetweenTwoNode(Guid startID， Guid endID)`

指定开始节点ID和终点节点ID，返回开始节点到终点节点的所有路径

#### **函数：GetAllPathFromStartNode**
`List<List<Guid>> GetAllPathFromStartNode(Guid targetNodeID)`

指定目的节点ID，返回所有起始节点到目的节点的所有路径

## 单元测试
单元测试说明文档 [下载][2]


  [1]: http://oevwfwaro.bkt.clouddn.com/%E6%B7%B1%E5%BA%A6%E4%BC%98%E5%85%88%E9%81%8D%E5%8E%86.gif
  [2]: http://oevwfwaro.bkt.clouddn.com/pathTraversal%20%E5%87%BD%E6%95%B0%E5%8F%8A%E5%8D%95%E5%85%83%E6%B5%8B%E8%AF%95%E8%AF%B4%E6%98%8E%E6%96%87%E6%A1%A3%20.docx
