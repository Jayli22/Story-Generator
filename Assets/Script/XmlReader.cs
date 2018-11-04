using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class XmlReader {

    private Dictionary<string, ArrayList> xmlmap = new Dictionary<string, ArrayList>();
    private ArrayList localxmllist = new ArrayList();
    public Dictionary<string, ArrayList> Xmlmap
    {
        get
        {
            return xmlmap;
        }

        set
        {
            xmlmap = value;
        }
    }

    public ArrayList Localxmllist
    {
        get
        {
            return localxmllist;
        }

        set
        {
            localxmllist = value;
        }
    }

    public void CreateXML()
    {
        string path = Application.dataPath + "/Story/data2.xml"; if (!File.Exists(path))
        {
            XmlDocument xml = new XmlDocument();            //创建最上一层的节点。            
            XmlElement root = xml.CreateElement("objects");            //创建子节点            
            XmlElement element = xml.CreateElement("messages");            //设置节点的属性            
            element.SetAttribute("id", "1");
            element.SetAttribute("name", "2");
            XmlElement elementChild1 = xml.CreateElement("contents");
            elementChild1.SetAttribute("name", "a");            //设置节点内面的内容           
            elementChild1.InnerText = "这就是你，你就是天狼";
            XmlElement elementChild2 = xml.CreateElement("mission");
            elementChild2.SetAttribute("map", "abc");
            elementChild2.InnerText = "去吧，少年，去实现你的梦想";     //把节点一层一层的添加至xml中，注意他们之间的先后顺序，这是生成XML文件的顺序
            element.AppendChild(elementChild1);
            element.AppendChild(elementChild2);
            root.AppendChild(element);
            xml.AppendChild(root);            //最后保存文件            
            xml.Save(path);        }
    }

    public ArrayList LoadXml(string piecesName)    {
        ArrayList x = new ArrayList() ;
            //创建xml文档        
            XmlDocument xml = new XmlDocument();
            xml.Load(Application.dataPath + "/Story/"+piecesName);        //得到objects节点下的所有子节点        
            XmlNodeList xmlNodeList = xml.SelectSingleNode("Pieces").ChildNodes;
            //遍历所有子节点        
            int i = 0;
        while (i < xmlNodeList.Count)
        {
            XmlNode a = xmlNodeList.Item(i);
            x.Add(a.InnerText);
            i++;
        }
        return x;
        
    }      
    
    public void LoadXmlMap()
    {
        GetDirs(Application.dataPath + "/Story/");
        Debug.Log(localxmllist.Count);
        for(int i=0;i< localxmllist.Count;i++)
        {
            xmlmap.Add(localxmllist[i].ToString(), LoadXml(localxmllist[i].ToString()));
        }
    }
    
    //修改    

    public void updateXML(string filename)
    {
        string path = Application.dataPath + "Story"+filename+".xml";
        if (File.Exists(path))
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList xmlNodeList = xml.SelectSingleNode("Pieces").ChildNodes;
            foreach (XmlElement xl1 in xmlNodeList)
            {
                if (xl1.GetAttribute("id") == "1")
                {
                    //把messages里id为1的属性改为5             
                    xl1.SetAttribute("id", "5");
                }
                if (xl1.GetAttribute("id") == "5")
                {
                    foreach (XmlElement xl2 in xl1.ChildNodes)
                    {
                        if (xl2.GetAttribute("map") == "abc")
                        {
                            //把mission里map为abc的属性改为df，并修改其里面的内容    
                            xl2.SetAttribute("map", "df");
                            xl2.InnerText = "我成功改变了你";
                        }
                    }
                }
            }
            xml.Save(path);
        }
    }     
    //添加XML 
    public void addXMLData(string filename,string addtext)
    {
        string path = Application.dataPath + "/Story/"+filename+".xml";
        if (File.Exists(path))
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNode root = xml.SelectSingleNode("Pieces");
            //下面的东西就跟上面创建xml元素是一样的。我们把他复制过来就行了 
            XmlElement element = xml.CreateElement(filename);
            //设置节点内面的内容         
            element.InnerText = addtext;
            root.AppendChild(element);
            //最后保存文件        
            xml.Save(path);
        }
    }

    private  void GetDirs(string dirPath)
    {
        int i = 0;
        foreach (string path in Directory.GetFiles(dirPath))
        {
            //获取所有文件夹中包含后缀为 .prefab 的路径
            if (System.IO.Path.GetExtension(path) == ".xml")
            {
                //dirs.Add(path.Substring(path.IndexOf("Assets")));
                string[] a = path.Substring(path.IndexOf("Assets")).Split('/'); 
                localxmllist.Add(a[2]);
               Debug.Log(a[2]);
            }
        }

        if (Directory.GetDirectories(dirPath).Length > 0)  //遍历所有文件夹
        {
            foreach (string path in Directory.GetDirectories(dirPath))
            {
                //GetDirs(path, ref dirs);
            }
        }
    }
}



