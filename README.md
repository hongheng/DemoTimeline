# DemoTimeline

https://docs.unity3d.com/Manual/TimelineSection.html

民间翻译：
1. https://www.jianshu.com/p/ba460e5a2b6d
1. https://www.jianshu.com/p/d79ed20f4d47
1. https://www.jianshu.com/p/527e74eb59ca

## 概述

Timeline由以下构成：

* Timeline Asset： 存储"未绑定物体"的track、clip、动画信息。对应于timeline文件，存储于资源目录中。
* Timeline instance： 存储timeline asset和具体物体的绑定信息。体现在Playable Director组件，存储于场景中。

## Timeline 和 Animation 的区别

动画| animation | timeline
--| -- | --
绑定机制 | 使用层级路径记录动画的作用对象 | 专门的绑定列表
控制机制 | 专属的animation controller控制 | 由timeline生成的runtime animation controller控制
适用对象 | 单个物体、或者单个层级树下的多个物体 | 多种track、每个track可以包含多个clip。复杂层级的多个物体、音效、粒子

## 工作流

1. 创建timeline：使用 Window > Sequencing > Timeline 窗口，可以创建和编辑Timeline。

        新建操作：点击场景中某个GameObject，点击Create。
        * 项目中，新建 xxxTimeline.playable ，并预建一个 Animation track。
        * 在指定的对象上，新建Playable Director组件、animator组件，并将后者绑定到上一步预建的track上。

1. 录制动画：点击track栏的红色圆圈开始录制。此时生成的是没有起止时间的Infinite clip，点击track栏菜单“Convert to Clip Track”后，可以自由移动、裁剪、混合等。

1. 覆盖动画：点击track栏菜单“Add Override Track”

p.s. 对clip的操作，详见https://docs.unity3d.com/Manual/TimelineClipsView.html

p.s. 对curve的操作，与Animation类似，详见https://docs.unity3d.com/Manual/TimelineCurvesView.html

### Playable Director 

* Update Method。 更新模式：音频时钟、游戏时钟、未缩放的游戏时钟、手动（脚本赋值）。
* Play on Awake。 自启动开关。
* Wrap Mode。 结束后的行为：保持、循环、无。
* Initial Time。 初始化的时间点
* Current Time。 当前的时间点（运行时出现）
* Bindings。 track需要绑定的物体

## Playable 扩展

官方工具：https://assetstore.unity.com/packages/essentials/default-playables-95266

自动化脚本生成器 + 常用扩展（灯光、导航、位移、文本、变速、视频等）

### Timeline Playable Wizard

1. 通用设置

        * Playable Name。会以此生成附带各种后缀（Behaviour/Clip/MixerBehaviour/Track/Drawer）的脚本。
        * Track Binding。Track要绑定的类型。
        * Track Color。Track在编辑器中的颜色。
        * Show Help。展示参数提示。

1. 全自动模式：Standard Blend Playable

        * Default Values。默认值。
        * Standard Blend Playable Properties。可以在timeline中控制的参数。

1. 自定义模式：Normal Playable

        * Exposed References。外部引用，可以引用场景中的物体。（以位移为例，可以是目标物体）
        * Behaviour Variables。行为参数，自定义行为中需要的参数。（以位移为例，可以是速度）
        * Clip Caps。Clip是否可以被混合等编辑特性。详见 https://docs.unity3d.com/ScriptReference/Timeline.ClipCaps.html
        * Create Drawer?。是否创建Drawer。
