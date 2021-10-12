    [XmlRoot(ElementName="gem")]
    public class gem
    {
        [XmlAttribute(AttributeName="system")]
        public String system { get; set; }
        [XmlAttribute(AttributeName="property")]
        public String property { get; set; }
    }

    [XmlRoot(ElementName="ucc")]
    public class ucc
    {
        [XmlAttribute(AttributeName="mesh")]
        public String mesh { get; set; }
    }

    [XmlRoot(ElementName="drop")]
    public class drop
    {
        [XmlAttribute(AttributeName="dropNif")]
        public String dropNif { get; set; }
        [XmlAttribute(AttributeName="dropDisplay")]
        public String dropDisplay { get; set; }
    }

    [XmlRoot(ElementName="life")]
    public class life
    {
        [XmlAttribute(AttributeName="usePeriod")]
        public String usePeriod { get; set; }
        [XmlAttribute(AttributeName="expirationPeriod")]
        public String expirationPeriod { get; set; }
    }

    [XmlRoot(ElementName="pet")]
    public class pet
    {
        [XmlAttribute(AttributeName="petID")]
        public String petID { get; set; }
    }

    [XmlRoot(ElementName="ride")]
    public class ride
    {
        [XmlAttribute(AttributeName="rideBuildScale")]
        public String rideBuildScale { get; set; }
        [XmlAttribute(AttributeName="rideMonster")]
        public String rideMonster { get; set; }
    }

    [XmlRoot(ElementName="basic")]
    public class basic
    {
        [XmlAttribute(AttributeName="friendly")]
        public String friendly { get; set; }
        [XmlAttribute(AttributeName="stringTag")]
        public String stringTag { get; set; }
    }

    [XmlRoot(ElementName="physx")]
    public class physx
    {
        [XmlAttribute(AttributeName="action")]
        public String action { get; set; }
    }

    [XmlRoot(ElementName="asset")]
    public class asset
    {
        [XmlElement(ElementName="physx")]
        public physx physx { get; set; }
        [XmlAttribute(AttributeName="name")]
        public String name { get; set; }
        [XmlAttribute(AttributeName="selfnode")]
        public String selfnode { get; set; }
        [XmlAttribute(AttributeName="targetnode")]
        public String targetnode { get; set; }
        [XmlAttribute(AttributeName="attachnode")]
        public String attachnode { get; set; }
        [XmlAttribute(AttributeName="pony")]
        public String pony { get; set; }
        [XmlAttribute(AttributeName="zalign")]
        public String zalign { get; set; }
        [XmlAttribute(AttributeName="replace")]
        public String replace { get; set; }
        [XmlAttribute(AttributeName="earfold")]
        public String earfold { get; set; }
        [XmlAttribute(AttributeName="ani")]
        public String ani { get; set; }
        [XmlAttribute(AttributeName="emotionhide")]
        public String emotionhide { get; set; }
        [XmlAttribute(AttributeName="gender")]
        public String gender { get; set; }
        [XmlAttribute(AttributeName="capscale")]
        public String capscale { get; set; }
        [XmlAttribute(AttributeName="weapon")]
        public String weapon { get; set; }
        [XmlAttribute(AttributeName="placeable")]
        public String placeable { get; set; }
    }

    [XmlRoot(ElementName="slot")]
    public class slot
    {
        [XmlElement(ElementName="asset")]
        public asset asset { get; set; }
        [XmlElement(ElementName="decal")]
        public String decal { get; set; }
        [XmlAttribute(AttributeName="name")]
        public String name { get; set; }
    }

    [XmlRoot(ElementName="slots")]
    public class slots
    {
        [XmlElement(ElementName="slot")]
        public slot slot { get; set; }
    }

    [XmlRoot(ElementName="limit")]
    public class limit
    {
        [XmlAttribute(AttributeName="jobLimit")]
        public String jobLimit { get; set; }
        [XmlAttribute(AttributeName="recommendJobs")]
        public String recommendJobs { get; set; }
        [XmlAttribute(AttributeName="levelLimit")]
        public String levelLimit { get; set; }
        [XmlAttribute(AttributeName="levelLimitMax")]
        public String levelLimitMax { get; set; }
        [XmlAttribute(AttributeName="genderLimit")]
        public String genderLimit { get; set; }
        [XmlAttribute(AttributeName="transferType")]
        public String transferType { get; set; }
        [XmlAttribute(AttributeName="shopSell")]
        public String shopSell { get; set; }
        [XmlAttribute(AttributeName="enableBreak")]
        public String enableBreak { get; set; }
        [XmlAttribute(AttributeName="enableRegisterMeratMarket")]
        public String enableRegisterMeratMarket { get; set; }
        [XmlAttribute(AttributeName="exceptEnchant")]
        public String exceptEnchant { get; set; }
    }

    [XmlRoot(ElementName="skill")]
    public class skill
    {
        [XmlAttribute(AttributeName="skillID")]
        public String skillID { get; set; }
        [XmlAttribute(AttributeName="skillLevel")]
        public String skillLevel { get; set; }
    }

    [XmlRoot(ElementName="objectWeaponSkill")]
    public class objectWeaponSkill
    {
        [XmlAttribute(AttributeName="skillID")]
        public String skillID { get; set; }
        [XmlAttribute(AttributeName="skillLevel")]
        public String skillLevel { get; set; }
    }

    [XmlRoot(ElementName="title")]
    public class title
    {
        [XmlAttribute(AttributeName="maxCount")]
        public String maxCount { get; set; }
    }

    [XmlRoot(ElementName="effect")]
    public class effect
    {
        [XmlAttribute(AttributeName="enchantShape")]
        public String enchantShape { get; set; }
        [XmlAttribute(AttributeName="idle")]
        public String idle { get; set; }
        [XmlAttribute(AttributeName="battleIdle")]
        public String battleIdle { get; set; }
        [XmlAttribute(AttributeName="characterIdle")]
        public String characterIdle { get; set; }
        [XmlAttribute(AttributeName="characterBattleIdle")]
        public String characterBattleIdle { get; set; }
    }

    [XmlRoot(ElementName="fusion")]
    public class fusion
    {
        [XmlAttribute(AttributeName="fusionable")]
        public String fusionable { get; set; }
    }

    [XmlRoot(ElementName="install")]
    public class install
    {
        [XmlAttribute(AttributeName="placeable")]
        public String placeable { get; set; }
        [XmlAttribute(AttributeName="unchangeable")]
        public String unchangeable { get; set; }
        [XmlAttribute(AttributeName="cannotStackAttach")]
        public String cannotStackAttach { get; set; }
        [XmlAttribute(AttributeName="stackable")]
        public String stackable { get; set; }
        [XmlAttribute(AttributeName="stackableD")]
        public String stackableD { get; set; }
        [XmlAttribute(AttributeName="attachable")]
        public String attachable { get; set; }
        [XmlAttribute(AttributeName="wall")]
        public String wall { get; set; }
        [XmlAttribute(AttributeName="generatePhysX")]
        public String generatePhysX { get; set; }
        [XmlAttribute(AttributeName="cubeProp")]
        public String cubeProp { get; set; }
        [XmlAttribute(AttributeName="space")]
        public String space { get; set; }
        [XmlAttribute(AttributeName="animatable")]
        public String animatable { get; set; }
        [XmlAttribute(AttributeName="funcCode")]
        public String funcCode { get; set; }
        [XmlAttribute(AttributeName="objCode")]
        public String objCode { get; set; }
        [XmlAttribute(AttributeName="staticAngle")]
        public String staticAngle { get; set; }
        [XmlAttribute(AttributeName="indoor")]
        public String indoor { get; set; }
        [XmlAttribute(AttributeName="bankType")]
        public String bankType { get; set; }
        [XmlAttribute(AttributeName="asset")]
        public String asset { get; set; }
        [XmlAttribute(AttributeName="preset")]
        public String preset { get; set; }
        [XmlAttribute(AttributeName="physXdimension")]
        public String physXdimension { get; set; }
        [XmlAttribute(AttributeName="mapAttribute")]
        public String mapAttribute { get; set; }
        [XmlAttribute(AttributeName="propCollisionGroup")]
        public String propCollisionGroup { get; set; }
    }

    [XmlRoot(ElementName="material")]
    public class material
    {
        [XmlAttribute(AttributeName="ui")]
        public String ui { get; set; }
        [XmlAttribute(AttributeName="attack")]
        public String attack { get; set; }
    }

    [XmlRoot(ElementName="sell")]
    public class sell
    {
        [XmlAttribute(AttributeName="price")]
        public String price { get; set; }
        [XmlAttribute(AttributeName="priceCustom")]
        public String priceCustom { get; set; }
    }

    [XmlRoot(ElementName="exp")]
    public class exp
    {
        [XmlAttribute(AttributeName="attackExp")]
        public String attackExp { get; set; }
        [XmlAttribute(AttributeName="lifeExp")]
        public String lifeExp { get; set; }
        [XmlAttribute(AttributeName="adventureExp")]
        public String adventureExp { get; set; }
    }

    [XmlRoot(ElementName="property")]
    public class property
    {
        [XmlElement(ElementName="sell")]
        public sell sell { get; set; }
        [XmlElement(ElementName="exp")]
        public exp exp { get; set; }
        [XmlAttribute(AttributeName="skin")]
        public String skin { get; set; }
        [XmlAttribute(AttributeName="slotMax")]
        public String slotMax { get; set; }
        [XmlAttribute(AttributeName="slotIcon")]
        public String slotIcon { get; set; }
        [XmlAttribute(AttributeName="slotIconCustom")]
        public String slotIconCustom { get; set; }
        [XmlAttribute(AttributeName="type")]
        public String type { get; set; }
        [XmlAttribute(AttributeName="subtype")]
        public String subtype { get; set; }
        [XmlAttribute(AttributeName="itemGroup")]
        public String itemGroup { get; set; }
        [XmlAttribute(AttributeName="category")]
        public String category { get; set; }
        [XmlAttribute(AttributeName="blackMarketCategory")]
        public String blackMarketCategory { get; set; }
        [XmlAttribute(AttributeName="remakeDisable")]
        public String remakeDisable { get; set; }
        [XmlAttribute(AttributeName="iconCode")]
        public String iconCode { get; set; }
        [XmlAttribute(AttributeName="representOption")]
        public String representOption { get; set; }
        [XmlAttribute(AttributeName="movie")]
        public String movie { get; set; }
        [XmlAttribute(AttributeName="xmlData")]
        public String xmlData { get; set; }
        [XmlAttribute(AttributeName="presetPath")]
        public String presetPath { get; set; }
        [XmlAttribute(AttributeName="reference")]
        public String reference { get; set; }
        [XmlAttribute(AttributeName="gearScore")]
        public String gearScore { get; set; }
        [XmlAttribute(AttributeName="tradableCount")]
        public String tradableCount { get; set; }
        [XmlAttribute(AttributeName="rePackingLimitCount")]
        public String rePackingLimitCount { get; set; }
        [XmlAttribute(AttributeName="rePackingItemConsumeCount")]
        public String rePackingItemConsumeCount { get; set; }
        [XmlAttribute(AttributeName="collection")]
        public String collection { get; set; }
        [XmlAttribute(AttributeName="doNotPreview")]
        public String doNotPreview { get; set; }
        [XmlAttribute(AttributeName="doNotSkipRender")]
        public String doNotSkipRender { get; set; }
    }

    [XmlRoot(ElementName="mutation")]
    public class mutation
    {
        [XmlAttribute(AttributeName="interval")]
        public String interval { get; set; }
        [XmlAttribute(AttributeName="assets")]
        public String assets { get; set; }
        [XmlAttribute(AttributeName="skills")]
        public String skills { get; set; }
        [XmlAttribute(AttributeName="changeeffect")]
        public String changeeffect { get; set; }
    }

    [XmlRoot(ElementName="HR")]
    public class HR
    {
        [XmlAttribute(AttributeName="scale")]
        public String scale { get; set; }
        [XmlAttribute(AttributeName="pony")]
        public String pony { get; set; }
    }

    [XmlRoot(ElementName="FD")]
    public class FD
    {
        [XmlAttribute(AttributeName="translation")]
        public String translation { get; set; }
        [XmlAttribute(AttributeName="rotation")]
        public String rotation { get; set; }
        [XmlAttribute(AttributeName="scale")]
        public String scale { get; set; }
    }

    [XmlRoot(ElementName="CP")]
    public class CP
    {
        [XmlAttribute(AttributeName="xrotation")]
        public String xrotation { get; set; }
        [XmlAttribute(AttributeName="yrotation")]
        public String yrotation { get; set; }
        [XmlAttribute(AttributeName="zrotation")]
        public String zrotation { get; set; }
        [XmlAttribute(AttributeName="scale")]
        public String scale { get; set; }
        [XmlAttribute(AttributeName="attach")]
        public String attach { get; set; }
    }

    [XmlRoot(ElementName="customize")]
    public class customize
    {
        [XmlElement(ElementName="HR")]
        public HR HR { get; set; }
        [XmlElement(ElementName="FD")]
        public FD FD { get; set; }
        [XmlElement(ElementName="CP")]
        public CP CP { get; set; }
        [XmlAttribute(AttributeName="colorPalette")]
        public String colorPalette { get; set; }
        [XmlAttribute(AttributeName="color")]
        public String color { get; set; }
        [XmlAttribute(AttributeName="colordetail")]
        public String colordetail { get; set; }
        [XmlAttribute(AttributeName="ch0")]
        public String ch0 { get; set; }
        [XmlAttribute(AttributeName="ch1")]
        public String ch1 { get; set; }
        [XmlAttribute(AttributeName="ch2")]
        public String ch2 { get; set; }
        [XmlAttribute(AttributeName="defaultColorIndex")]
        public String defaultColorIndex { get; set; }
    }

    [XmlRoot(ElementName="function")]
    public class function
    {
        [XmlAttribute(AttributeName="name")]
        public String name { get; set; }
        [XmlAttribute(AttributeName="parameter")]
        public String parameter { get; set; }
        [XmlAttribute(AttributeName="onlyShadowContinent")]
        public String onlyShadowContinent { get; set; }
    }

    [XmlRoot(ElementName="AdditionalEffect")]
    public class AdditionalEffect
    {
        [XmlAttribute(AttributeName="id")]
        public String id { get; set; }
        [XmlAttribute(AttributeName="level")]
        public String level { get; set; }
    }

    [XmlRoot(ElementName="tool")]
    public class tool
    {
        [XmlAttribute(AttributeName="itemPreset")]
        public String itemPreset { get; set; }
        [XmlAttribute(AttributeName="itemPresetPath")]
        public String itemPresetPath { get; set; }
    }

    [XmlRoot(ElementName="option")]
    public class option
    {
        [XmlAttribute(AttributeName="title")]
        public String title { get; set; }
        [XmlAttribute(AttributeName="static")]
        public String static { get; set; }
        [XmlAttribute(AttributeName="random")]
        public String random { get; set; }
        [XmlAttribute(AttributeName="constant")]
        public String constant { get; set; }
        [XmlAttribute(AttributeName="staticMakeType")]
        public String staticMakeType { get; set; }
        [XmlAttribute(AttributeName="randomMakeType")]
        public String randomMakeType { get; set; }
        [XmlAttribute(AttributeName="constantMakeType")]
        public String constantMakeType { get; set; }
        [XmlAttribute(AttributeName="optionRandom")]
        public String optionRandom { get; set; }
        [XmlAttribute(AttributeName="optionLevelFactor")]
        public String optionLevelFactor { get; set; }
        [XmlAttribute(AttributeName="optionID")]
        public String optionID { get; set; }
    }

    [XmlRoot(ElementName="maid")]
    public class maid
    {
        [XmlAttribute(AttributeName="maidID")]
        public String maidID { get; set; }
    }

    [XmlRoot(ElementName="PCBang")]
    public class PCBang
    {
        [XmlAttribute(AttributeName="PCBang")]
        public String PCBang { get; set; }
    }

    [XmlRoot(ElementName="MusicScore")]
    public class MusicScore
    {
        [XmlAttribute(AttributeName="playCount")]
        public String playCount { get; set; }
        [XmlAttribute(AttributeName="masteryValue")]
        public String masteryValue { get; set; }
        [XmlAttribute(AttributeName="masteryValueMax")]
        public String masteryValueMax { get; set; }
        [XmlAttribute(AttributeName="isCustomNote")]
        public String isCustomNote { get; set; }
        [XmlAttribute(AttributeName="noteLengthMax")]
        public String noteLengthMax { get; set; }
        [XmlAttribute(AttributeName="fileName")]
        public String fileName { get; set; }
        [XmlAttribute(AttributeName="playTime")]
        public String playTime { get; set; }
        [XmlAttribute(AttributeName="recommendCategoryId")]
        public String recommendCategoryId { get; set; }
    }

    [XmlRoot(ElementName="housing")]
    public class housing
    {
        [XmlAttribute(AttributeName="filter")]
        public String filter { get; set; }
        [XmlAttribute(AttributeName="categoryTag")]
        public String categoryTag { get; set; }
        [XmlAttribute(AttributeName="categoryIndex")]
        public String categoryIndex { get; set; }
        [XmlAttribute(AttributeName="trophyID")]
        public String trophyID { get; set; }
        [XmlAttribute(AttributeName="trophyLevel")]
        public String trophyLevel { get; set; }
        [XmlAttribute(AttributeName="interiorLevel")]
        public String interiorLevel { get; set; }
    }

    [XmlRoot(ElementName="environment")]
    public class environment
    {
        [XmlElement(ElementName="gem")]
        public gem gem { get; set; }
        [XmlElement(ElementName="ucc")]
        public ucc ucc { get; set; }
        [XmlElement(ElementName="drop")]
        public drop drop { get; set; }
        [XmlElement(ElementName="life")]
        public life life { get; set; }
        [XmlElement(ElementName="pet")]
        public pet pet { get; set; }
        [XmlElement(ElementName="ride")]
        public ride ride { get; set; }
        [XmlElement(ElementName="basic")]
        public basic basic { get; set; }
        [XmlElement(ElementName="slots")]
        public slots slots { get; set; }
        [XmlElement(ElementName="limit")]
        public limit limit { get; set; }
        [XmlElement(ElementName="skill")]
        public skill skill { get; set; }
        [XmlElement(ElementName="objectWeaponSkill")]
        public objectWeaponSkill objectWeaponSkill { get; set; }
        [XmlElement(ElementName="title")]
        public title title { get; set; }
        [XmlElement(ElementName="effect")]
        public effect effect { get; set; }
        [XmlElement(ElementName="fusion")]
        public fusion fusion { get; set; }
        [XmlElement(ElementName="cutting")]
        public String cutting { get; set; }
        [XmlElement(ElementName="install")]
        public install install { get; set; }
        [XmlElement(ElementName="material")]
        public material material { get; set; }
        [XmlElement(ElementName="property")]
        public property property { get; set; }
        [XmlElement(ElementName="mutation")]
        public mutation mutation { get; set; }
        [XmlElement(ElementName="customize")]
        public custom