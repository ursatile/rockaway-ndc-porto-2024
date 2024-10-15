using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Data.Sample;

public static partial class SampleData {
	public static class Artists {

		private static int seed = 1;
		private static Guid NextId => TestGuid(seed++, 'A');
		public static Artist AlterColumn = new(
			NextId,
			"Alter Column",
			"Alter Column are South Africa's hottest math rock export. Founded in Cape Town in 2021, their debut album \"Drop Table Mountain\" was nominated for four Grammy awards.",
			"alter-column"
		);

		public static Artist BodyBag = new(
			NextId,
			"<Body>Bag",
			"Speed metal pioneers from San Francisco, <Body>Bag helped define the “web rock” sound in the early 2020s.",
			"body-bag"
		);

		public static Artist Coda = new(
			NextId,
			"Coda",
			"Hailing from a distant future, Coda is a time-traveling rock band known for their mind-bending melodies that transport audiences through different eras, merging past and future into a harmonious blend of sound.",
			"coda"
		);

		public static Artist DevLeppard = new(
			NextId,
			"Dev Leppard",
			"Rising from the ashes of adversity, Dev Leppard is a fiercely talented rock band that overcame obstacles with sheer determination, captivating fans worldwide with their electrifying performances and showcasing a bond that empowers their music.",
			"dev-leppard"
		);

		public static Artist Elektronika = new(
			NextId,
			"Электроника",
			"Merging the realms of art and emotion, Электроника is an introspective rock group, infusing their hauntingly beautiful lyrics with mesmerizing melodies that delve into the depths of human existence, leaving listeners immersed in profound reflections.",
			"elektronika"
		);

		public static Artist ForEarTransform = new(
			NextId,
			"For Ear Transform",
			"With an otherworldly allure, For Ear Transform is an ethereal rock ensemble, their music transcends reality, leading listeners on a dreamlike journey where celestial harmonies and ethereal instrumentation create a captivating and transformative experience.",
			"for-ear-transform"
		);

		public static Artist GarbageCollectors = new(
			NextId,
			"Garbage Collectors",
			"Rebel rockers with a cause, Garbage Collectors are raw, raucous and unapologetic, fearlessly tackling social issues and societal norms in their music, energizing crowds with their powerful anthems and unyielding spirit.",
			"garbage-collectors"
		);

		public static Artist HaskellsAngels = new(
			NextId,
			"Haskell’s Angels",
			"Virtuosos of rhythm and harmony, Haskell’s Angels radiate a divine aura, blending complex melodies and celestial harmonies that resonate deep within the soul.",
			"haskells-angels"
		);

		public static Artist IronMedian = new(
			NextId,
			"Iron Median",
			"A force to be reckoned with, Iron Median are known for their thunderous beats and adrenaline-pumping anthems, electrifying audiences with their commanding stage presence and unstoppable energy.",
			"iron-median"
		);

		public static Artist JavasCrypt = new(
			NextId,
			"Java’s Crypt",
			"Enigmatic and mysterious, Java’s Crypt are shrouded in secrecy, their enigmatic melodies and cryptic lyrics take listeners on a thrilling journey through the unknown realms of music.",
			"javas-crypt"
		);

		public static Artist KillerBite = new(
			NextId,
			"Killer Bite",
			"An electrifying whirlwind, Killer Bite unleash a torrent of energy through their performances, captivating audiences with their explosive riffs and heart-pounding rhythms.",
			"killer-bite"
		);

		public static Artist LambdaOfGod = new(
			NextId,
			"Lambda of God",
			"Pioneers of progressive rock, Lambda of God is an innovative band that pushes the boundaries of musical expression, combining intricate compositions and thought-provoking lyrics that resonate deeply with their dedicated fanbase.",
			"lambda-of-god"
		);

		public static Artist NullTerminatedStringBand = new(
			NextId,
			"Null Terminated String Band",
			"Quirky and witty, the Null Terminated String Band is a rock group that weaves clever humor and geeky references into their catchy tunes, bringing a smile to the faces of both tech enthusiasts and music lovers alike.",
			"null-terminated-string-band"
		);

		public static Artist MottTheTuple = new(
			NextId,
			"Mott the Tuple",
			"A charismatic ensemble, Mott the Tuple blends vintage charm with a modern edge, creating a unique sound that captivates audiences and takes them on a nostalgic journey through time.",
			"mott-the-tuple"
		);

		public static Artist Overflow = new(
			NextId,
			"Överflow",
			"Overflowing with passion and intensity, Överflow is a rock band that immerses listeners in a tsunami of sound, exploring emotions through powerful melodies and soul-stirring performances.",
			"overflow"
		);

		public static Artist PascalsWager = new(
			NextId,
			"Pascal’s Wager",
			"Philosophers of rock, Pascal’s Wager delves into existential themes with their intellectually charged songs, prompting listeners to ponder the profound questions of life and purpose.",
			"pascals-wager"
		);

		public static Artist QuantumGate = new(
			NextId,
			"Qüantum Gäte",
			"Futuristic and avant-garde, Qüantum Gäte defy conventions, using experimental sounds and innovative compositions to transport listeners to other dimensions of music.",
			"quantum-gate"
		);

		public static Artist RunCmd = new(
			NextId,
			"Run CMD",
			"High-energy and rebellious, Run CMD is a rock band that merges technology themes with headbanging-worthy tunes, igniting the stage with their electrifying presence and infectious enthusiasm.",
			"run-cmd"
		);

		public static Artist ScriptKiddies = new(
			NextId,
			"<Script>Kiddies",
			"Mischievous and bold, <Script>Kiddies subvert expectations with clever musical pranks, weaving clever wordplay and tongue-in-cheek humor into their audacious performances.",
			"script-kiddies"
		);

		public static Artist Terrorform = new(
			NextId,
			"Terrorform",
			"Masters of atmosphere, Terrorform’s dark and atmospheric rock ensembles conjure hauntingly beautiful soundscapes that captivate the senses and evoke a deep emotional response.",
			"terrorform"
		);

		public static Artist Unicoder = new(
			NextId,
			"ᵾnɨȼøđɇɍ",
			"ᵾnɨȼøđɇɍ harmonize complex equations and melodies, weaving a symphony of logic and emotion in their unique and captivating music.",
			"unicoder"
		);

		public static Artist VirtualMachine = new(
			NextId,
			"Virtual Machine",
			"Bridging reality and virtuality, Virtual Machine is a surreal rock group that blurs the lines between the tangible and the digital, creating mind-bending performances that leave audiences questioning the nature of existence.",
			"virtual-machine"
		);

		public static Artist WebmasterOfPuppets = new(
			NextId,
			"Webmaster of Puppets",
			"Technologically savvy and creatively ambitious, Webmaster of Puppets is a web-inspired rock band, crafting narratives of digital dominance and manipulation with their inventive music.",
			"webmaster-of-puppets"
		);

		public static Artist Xslte = new(
			NextId,
			"XSLTE",
			"Mesmerizing and genre-defying, XSLTE is an enchanting rock ensemble that fuses electronic and rock elements, creating a spellbinding sound that enthralls listeners and transports them to MakeArtist sonic landscapes.",
			"xslte"
		);

		public static Artist Yamb = new(
			NextId,
			"YAMB",
			"Youthful and exuberant, YAMB spreads positivity and infectious energy through their music, connecting with fans through their youthful spirit and heartwarming performances.",
			"yamb"
		);

		public static Artist ZeroBasedIndex = new(
			NextId,
			"Zero Based Index",
			"Innovative and exploratory, Zero Based Index starts from scratch, building powerful narratives through their dynamic sound, leaving audiences inspired and moved by their expressive and daring music.",
			"zero-based-index"
		);

		public static Artist Ærbårn = new(
			NextId,
			"Ærbårn",
			"Inspired by their Australian namesakes, Ærbårn are Scandinavia's #1 party rock band. Thundering drums, huge guitar riffs and enough energy to light up the Arctic Circle, their shows have had amazing reviews all over the world",
			"aerbaarn"
		);

		public static Artist DotDotDot = new(
			NextId,
			"...",
			"dot-dot-dot to their friends (and fans), ... are a Canadian drone jazz combo formed in Vancouver in 1998, known for their thunderous horn section and innovative visuals.",
			"dot-dot-dot"
		);

		public static Artist SilverMountainStringBand = new(
			NextId,
			"The Silver Mountain String Band featuring Timber J. MacCorkindale and the Hill Valley Hornswogglers",
			"Known as the \"Silver Mountain Strings\" if you're into the whole brevity thing, Kentucky's answer to the Leningrad Cowboys has gone from strength to strength, from the Superbowl half time show to their sold-out Vegas residency in 2023.",
			"silver-mountain-string-band"
		);

		public static IEnumerable<Artist> AllArtists = new[] {
			AlterColumn, BodyBag, Coda, DevLeppard, Elektronika, ForEarTransform,
			GarbageCollectors, HaskellsAngels, IronMedian, JavasCrypt, KillerBite,
			LambdaOfGod, MottTheTuple, NullTerminatedStringBand, Overflow, PascalsWager,
			QuantumGate, RunCmd, ScriptKiddies, Terrorform, Unicoder,
			VirtualMachine, WebmasterOfPuppets, Xslte, Yamb, ZeroBasedIndex,
			Ærbårn, DotDotDot, SilverMountainStringBand
		};
	}
}