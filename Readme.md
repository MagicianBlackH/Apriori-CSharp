### 环境 / Environment：
Visual Studio 2019

.net 3.1

### 使用 / Usage：
直接实例化Apriori对象即可，例子如下：

Just instantiate the Apriori object directly. For example:
```C#
Apriori a = new Apriori(0.6, 0.6, dataList);
```
其构造函数的参数如下：

Its constructor has the following parameters:
```C#
/** 
 * support - 支持度
 * confidence - 置信度
 * data - 数据List
 */
public Apriori (double support, double confidence, List<string> data)
{
  ...
}
```
需注意：data的每一条string，都应该是用英文逗号隔开每一项，例如：

Remember that, each string of data should be separated by a comma. For example:

![image](https://github.com/MagicianBlackH/my-image-hosting-service/blob/master/Apriori-CSharp/OriginData.png?raw=true)

并且，里面的每一项的前置空格和后置空格在处理时都会被去除。

And, the leading and trailing spaces for each item will be trim.

在使用构造函数后，支持度与置信度结果将会分别存储于变量 `iterationResult` 和 `confidenceResult` 中。

After instantiating, the results will be stored in the variables `iterationResult` and `confidenceResult` respectively

可以分别通过对象调用 `ShowIteration` 和 `ShowConfidence` 获得结果，例如：

The results can be obtained by calling `ShowIteration` and `ShowConfidence` from the Apriori object respectively. For example:
```C#
a.ShowIteration();
a.ShowConfidence();
```

![image](https://github.com/MagicianBlackH/my-image-hosting-service/blob/master/Apriori-CSharp/result.png?raw=true)

需要的话，也可以通过 `ShowOriginData` 展示原数据。

If you like, you can get the origin data by calling `ShowOriginData`. For example:
```C#
a.ShowOriginData();
```
![image](https://github.com/MagicianBlackH/my-image-hosting-service/blob/master/Apriori-CSharp/ShowOriginData.png?raw=true)
