using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;



namespace punyaKito
{
    static class Constants
    {
        public const string path = "../../../shader/";
        public const string pathR = "../../../shadersR/";
        public const string pathV = "../../../shadersV/";
    }
    internal class Window : GameWindow
    {
        Asset3d[] _object3d = new Asset3d[20];
        List<Asset3d> _objects = new List<Asset3d>();
        List<Asset3d> _objectsAwan = new List<Asset3d>();
        List<Asset3d> _objects1 = new List<Asset3d>();
        List<Asset3d> _objectsV = new List<Asset3d>(); // bahu
        List<Asset3d> _objectsDua = new List<Asset3d>(); // plankton
        List<Asset3d> _objectsBotol = new List<Asset3d>(); // botol
        List<Asset3d> karen = new List<Asset3d>(); // ndas
        List<Asset3d> karen2 = new List<Asset3d>();// leher sikil
        List<Asset3d> karen3 = new List<Asset3d>();// roda
        List<Asset3d> karen4 = new List<Asset3d>();// roda
        List<Asset3d> karen5 = new List<Asset3d>();// roda
        List<Asset3d> karen6 = new List<Asset3d>();// roda
        List<Asset3d> pelangi = new List<Asset3d>();// pelangi

        double _time;
        float degr = 0;
        Camera _camera;
        bool _firstMove = true;
        Vector2 _lastPos;
        Vector3 _objecPost = new Vector3(0.0f, 0.0f, 0.0f);
        float _rotationSpeed = 1f;
        float totalTime;
        float speed = 0.1f;
        float speed2 = 0.1f;
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.Enable(EnableCap.DepthTest);
            //ganti background
            GL.ClearColor(0.43f, 0.878f, 0.917f, 1.0f);

            var kepala = new Asset3d(); //parent 1
            kepala.createBoxVertices2(0.0f, 0.0f, 0.0f, 1.0f);//ijo
            kepala.load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);
            _objects.Add(kepala);

            var gundukan = new Asset3d();
            gundukan.createHalfEllipsoid(0.5f, 0.5f, 0.6f, -0.5f, 0.1f, -0.32f, 100, 100);//bukit1
            gundukan.load(Constants.path + "shader.vert", Constants.path + "shader8.frag", Size.X, Size.Y);
            kepala.Child.Add(gundukan);

            var gundukan1 = new Asset3d();
            gundukan1.createHalfEllipsoid(0.5f, 0.9f, 0.6f, -0.5f, 0.1f, 0.32f, 100, 100);//bukit2
            gundukan1.load(Constants.path + "shader.vert", Constants.path + "shader8.frag", Size.X, Size.Y);
            kepala.Child.Add(gundukan1);

            var rumahpatrik = new Asset3d();//parent 2
            rumahpatrik.createHalfEllipsoid(0.30f, 0.30f, 0.3f, 2.5f, 0.1f, -0.6f, 100, 100);//rumahspatrik
            rumahpatrik.load(Constants.path + "shader.vert", Constants.path + "shader2.frag", Size.X, Size.Y);//rumahpatrk
            _objects.Add(rumahpatrik);

            var ataprumahpatrick = new Asset3d();
            ataprumahpatrick.createCylinder(0.01f, 0.15f, 2.5f, 0.4f, -0.6f);
            ataprumahpatrick.load(Constants.path + "shader.vert", Constants.path + "shader2.frag", Size.X, Size.Y);//rumahpatrk
            _objects.Add(ataprumahpatrick);

            var putih = new Asset3d();
            putih.createBoxVertices2(2.398f, 0.0f, 0.0f, 1.0f);//putih
            putih.load(Constants.path + "shader.vert", Constants.path + "shader3.frag", Size.X, Size.Y);
            kepala.Child.Add(putih);

            var jalan = new Asset3d();
            jalan.createBoxVertices3(1.2f, 0.0f, 0.0f, 1.0f);//jalan
            jalan.load(Constants.path + "shader.vert", Constants.path + "shader4.frag", Size.X, Size.Y);
            kepala.Child.Add(jalan);


            var rumahSquid = new Asset3d();
            rumahSquid.createCylinder2(0.1f, 0.2f, 0.5f, 2.0f, 0.3f, 0.0f); // iki wes bener tapi ra solid ddi elek
            rumahSquid.load(Constants.path + "shader.vert", Constants.path + "shader5.frag", Size.X, Size.Y);//rumahsquid55
            kepala.Child.Add(rumahSquid);


            var jendelaSquidKiri = new Asset3d();
            jendelaSquidKiri.createCylinder(0.04f, 0.01f, 1.88f, 0.43f, 0.07f); // z nya jadi x,x nya jadi z, y nya jadi atas bawah
            jendelaSquidKiri.load(Constants.path + "shader.vert", Constants.path + "shader6.frag", Size.X, Size.Y);//Jendela squid
            jendelaSquidKiri.rotatede(jendelaSquidKiri._centerPosition, jendelaSquidKiri._euler[2], 90);
            _objects.Add(jendelaSquidKiri);
        
            var jendelaSquidKanan = new Asset3d();
            jendelaSquidKanan.createCylinder(0.04f, 0.01f, 1.88f, 0.43f, -0.07f);
            jendelaSquidKanan.load(Constants.path + "shader.vert", Constants.path + "shader6.frag", Size.X, Size.Y);//Jendela squid
            jendelaSquidKanan.rotatede(jendelaSquidKiri._centerPosition, jendelaSquidKiri._euler[2], 90);
            _objects.Add(jendelaSquidKanan);

            var rumahHidung = new Asset3d();
            rumahHidung.createBoxVerticesBaru(1.87f, 0.35f, 0.0f, 0.03f, 0.1f, 0.2f, 0.03f);//hidung squid
            rumahHidung.load(Constants.path + "shader.vert", Constants.path + "shader6.frag", Size.X, Size.Y);
            rumahHidung.rotatede(rumahHidung._centerPosition, rumahHidung._euler[2], -13);
            _objects.Add(rumahHidung);

            var rumahPintu = new Asset3d();
            rumahPintu.createBoxVerticesBaru(1.81f, 0.15f, 0.0f, 0.03f, 0.01f, 0.1f, 0.06f);//pintusquid
            rumahPintu.load(Constants.path + "shader.vert", Constants.path + "shader7.frag", Size.X, Size.Y);
            _objects.Add(rumahPintu);

            var rumahSponge = new Asset3d();
            rumahSponge.createHalfEllipsoid(0.28f, -0.6f, 0.3f, -2.5f, -0.08f, 0.6f, 100, 100);
            rumahSponge.load(Constants.path + "shader.vert", Constants.path + "shader7.frag", Size.X, Size.Y);//rumah sponge 
            rumahSponge.rotate(Vector3.Zero, Vector3.UnitZ, 180);
            kepala.Child.Add(rumahSponge);

            var rumahPintuSponge = new Asset3d();
            rumahPintuSponge.createBoxVerticesBaru(2.22f, 0.15f, 0.6f, 0.03f, 0.01f, 0.1f, 0.05f);//pintusponge
            rumahPintuSponge.load(Constants.path + "shader.vert", Constants.path + "shader6.frag", Size.X, Size.Y);
            rumahSquid.Child.Add(rumahPintuSponge);

            var jendelaSpongeKiri = new Asset3d();
            jendelaSpongeKiri.createCylinder(0.04f, 0.01f, 1.88f, 0.03f, 0.5f);
            jendelaSpongeKiri.load(Constants.path + "shader.vert", Constants.path + "shader6.frag", Size.X, Size.Y);//Jendela sponge kiri
            jendelaSpongeKiri.rotatede(jendelaSquidKiri._centerPosition, jendelaSquidKiri._euler[2], 90);
            jendelaSquidKiri.Child.Add(jendelaSpongeKiri);

            var jendelaSpongeKanan = new Asset3d();
            jendelaSpongeKanan.createCylinder(0.04f, 0.01f, 1.7f, 0.06f, 0.72f);
            jendelaSpongeKanan.load(Constants.path + "shader.vert", Constants.path + "shader6.frag", Size.X, Size.Y);//Jendela sponge kanan
            jendelaSpongeKanan.rotatede(jendelaSquidKiri._centerPosition, jendelaSquidKiri._euler[2], 90);
            jendelaSquidKiri.Child.Add(jendelaSpongeKanan);

            var atapDaun1 = new Asset3d();
            atapDaun1.createEllipsoid2(0.0f, 0.3f, 0.05f, 2.5f, 0.5f, 0.5f,100,100);
            atapDaun1.load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);//Jendela sponge kanan
            rumahSquid.Child.Add(atapDaun1);

            var atapDaun2 = new Asset3d();
            atapDaun2.createEllipsoid2(0.0f, 0.3f, 0.05f, 2.5f, 0.6f, 0.6f,100,100);
            atapDaun2.load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);//Jendela sponge kanan
            rumahSquid.Child.Add(atapDaun2);

            var atapDaun3 = new Asset3d();
            atapDaun3.createEllipsoid2(0.0f, 0.3f, 0.05f, 2.5f, 0.5f, 0.7f,100,100);
            atapDaun3.load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);//Jendela sponge kanan
            rumahSquid.Child.Add(atapDaun3);

            var markahjalan1 = new Asset3d();
            markahjalan1.createBoxVerticesBaru(1.2f, 0.1f, 0.03f, 0.01f, 0.02f, 0.01f, 0.06f);
            markahjalan1.load(Constants.path + "shader.vert", Constants.path + "shader9.frag", Size.X, Size.Y);//markah jalan 1
            kepala.Child.Add(markahjalan1);

            var markahjalan2 = new Asset3d();
            markahjalan2.createBoxVerticesBaru(1.2f, 0.1f, 0.4f, 0.01f, 0.02f, 0.01f, 0.06f);
            markahjalan2.load(Constants.path + "shader.vert", Constants.path + "shader9.frag", Size.X, Size.Y);//markah jalan 1
            kepala.Child.Add(markahjalan2);

            var markahjalan3 = new Asset3d();
            markahjalan3.createBoxVerticesBaru(1.2f, 0.1f, 0.75f, 0.01f, 0.02f, 0.01f, 0.06f);
            markahjalan3.load(Constants.path + "shader.vert", Constants.path + "shader9.frag", Size.X, Size.Y);//markah jalan 1
            kepala.Child.Add(markahjalan3);

            var markahjalan4 = new Asset3d();
            markahjalan4.createBoxVerticesBaru(1.2f, 0.1f, -0.4f, 0.01f, 0.02f, 0.01f, 0.06f);
            markahjalan4.load(Constants.path + "shader.vert", Constants.path + "shader9.frag", Size.X, Size.Y);//markah jalan 1
            kepala.Child.Add(markahjalan4);

            var markahjalan5 = new Asset3d();
            markahjalan5.createBoxVerticesBaru(1.2f, 0.1f, -0.75f, 0.01f, 0.02f, 0.01f, 0.06f);
            markahjalan5.load(Constants.path + "shader.vert", Constants.path + "shader9.frag", Size.X, Size.Y);//markah jalan 1
            kepala.Child.Add(markahjalan5);

            var awan1 = new Asset3d();
            awan1.createEllipsoid(0.6f, 0.2f, 0.5f, 1.0f, 1.7f, 1.5f);
            awan1.load(Constants.path + "shader.vert", Constants.path + "shader10.frag", Size.X, Size.Y);
            _objectsAwan.Add(awan1);

            var awan2 = new Asset3d();
            awan2.createEllipsoid(0.3f, 0.2f, 0.3f, 0.8f, 1.9f, 1.5f);
            awan2.load(Constants.path + "shader.vert", Constants.path + "shader10.frag", Size.X, Size.Y);
            _objectsAwan.Add(awan2);

            var awan3 = new Asset3d();
            awan3.createEllipsoid(0.3f, 0.3f, 0.3f, 1.2f, 1.9f, 1.5f);
            awan3.load(Constants.path + "shader.vert", Constants.path + "shader10.frag", Size.X, Size.Y);
            _objectsAwan.Add(awan3);


            var awan4 = new Asset3d();
            awan4.createEllipsoid(0.6f, 0.2f, 0.5f, 4.0f, 1.7f, 1.0f);
            awan4.load(Constants.path + "shader.vert", Constants.path + "shader10.frag", Size.X, Size.Y);
            _objectsAwan.Add(awan4);

            var awan5 = new Asset3d();
            awan5.createEllipsoid(0.3f, 0.2f, 0.3f, 3.8f, 1.9f, 1.0f);
            awan5.load(Constants.path + "shader.vert", Constants.path + "shader10.frag", Size.X, Size.Y);
            _objectsAwan.Add(awan5);

            var awan6 = new Asset3d();
            awan6.createEllipsoid(0.3f, 0.3f, 0.3f, 4.2f, 1.9f, 1.0f);
            awan6.load(Constants.path + "shader.vert", Constants.path + "shader10.frag", Size.X, Size.Y);
            _objectsAwan.Add(awan6);

            var awan7 = new Asset3d();
            awan7.createEllipsoid(0.6f, 0.2f, 0.5f, 2.0f, 1.7f, -1.8f);
            awan7.load(Constants.path + "shader.vert", Constants.path + "shader10.frag", Size.X, Size.Y);
            _objectsAwan.Add(awan7);

            var awan8 = new Asset3d();
            awan8.createEllipsoid(0.3f, 0.2f, 0.3f, 1.8f, 1.9f, -1.8f);
            awan8.load(Constants.path + "shader.vert", Constants.path + "shader10.frag", Size.X, Size.Y);
            _objectsAwan.Add(awan8);

            var awan9 = new Asset3d();
            awan9.createEllipsoid(0.3f, 0.3f, 0.3f, 2.2f, 1.9f, -1.8f);
            awan9.load(Constants.path + "shader.vert", Constants.path + "shader10.frag", Size.X, Size.Y);
            _objectsAwan.Add(awan9);

            //var ubur1 = new Asset3d();
            //ubur1.createHalfEllipsoid(0.05f, -0.05f, 0.05f, 0.5f, 0.3f, 0.5f);//ubur
            //ubur1.load(Constants.path + "shader.vert", Constants.path + "shader11.frag", Size.X, Size.Y);//ubur
            //_objects.Add(ubur1);

            var ubur2 = new Asset3d();
            ubur2.createHalfEllipsoid(0.05f, 0.05f, 0.05f, 0.6f, 0.3f, 0.2f, 100, 100);//ubur
            ubur2.load(Constants.path + "shader.vert", Constants.path + "shader11.frag", Size.X, Size.Y);//ubur
            _objects1.Add(ubur2);

            var ubur3 = new Asset3d();
            ubur3.createHalfEllipsoid(0.05f, 0.05f, 0.05f, 0.2f, 0.3f, 0.0f, 100, 100);//ubur
            ubur3.load(Constants.path + "shader.vert", Constants.path + "shader11.frag", Size.X, Size.Y);//ubur
            _objects1.Add(ubur3);

            var ubur4 = new Asset3d();
            ubur4.createHalfEllipsoid(0.05f, 0.05f, 0.05f, 0.8f, 0.3f, -0.4f, 100, 100);//ubur
            ubur4.load(Constants.path + "shader.vert", Constants.path + "shader11.frag", Size.X, Size.Y);//ubur
            _objects1.Add(ubur4);

            var ubur5 = new Asset3d();
            ubur5.createHalfEllipsoid(0.05f, 0.05f, 0.05f, 0.5f, 0.3f, -0.7f, 100, 100);//ubur
            ubur5.load(Constants.path + "shader.vert", Constants.path + "shader11.frag", Size.X, Size.Y);//ubur
            _objects1.Add(ubur5);




            //--------------------------------------------------------------------
            //--------------------------------------------------------------------
            //PLANKTON
            var kepalaP = new Asset3d(); //Parent 0
            kepalaP.createHalfEllipsoid(0.01f, -0.009f, 0.01f, 0.8f, 0.42f, 0.5f, 100, 100);//kepala
            kepalaP.load(Constants.pathV + "shader.vert", Constants.pathV + "shader.frag", Size.X, Size.Y);//kepala
            _objectsDua.Add(kepalaP);

            var bokong = new Asset3d();
            bokong.createHalfEllipsoid(0.01f, -0.009f, 0.01f, 0.8f, 0.39f, 0.5f, 100, 100);//bokong
            bokong.load(Constants.pathV + "shader.vert", Constants.pathV + "shader.frag", Size.X, Size.Y);//bokong
            _objectsDua.Add(bokong);

            var alis = new Asset3d();
            alis.createBoxVerticesBaru(0.8f, 0.425f, 0.4895f, 0.01f, 0.02f, 0.005f, 0.0f);
            alis.load(Constants.pathV + "shader.vert", Constants.pathV + "shader8.frag", Size.X, Size.Y);//alis kiri
            _objectsDua.Add(alis);

            var badan = new Asset3d();
            badan.createCylinder(0.010f, 0.03f, 0.8f, 0.4051f, 0.5f); //badan
            badan.load(Constants.pathV + "shader.vert", Constants.pathV + "shader.frag", Size.X, Size.Y);//badan
            _objectsDua.Add(badan); //parent 1

            var mata2 = new Asset3d();
            mata2.createEllipsoid2(0.005f, 0.008f, 0.0f, 0.8f, 0.415f, 0.489f, 72, 24);//mata
            mata2.load(Constants.pathV + "shader.vert", Constants.pathV + "shader2.frag", Size.X, Size.Y);//mata kuning
            _objectsDua.Add(mata2);

            var mata3 = new Asset3d();
            mata3.createEllipsoid2(0.003f, 0.003f, 0.0f, 0.8f, 0.415f, 0.487f, 72, 24); //mata merah
            mata3.load(Constants.pathV + "shader.vert", Constants.pathV + "shader3.frag", Size.X, Size.Y);//mata merah
            _objectsDua.Add(mata3);

            var mata1 = new Asset3d();
            mata1.createEllipsoid2(0.001f, 0.001f, 0.0f, 0.8f, 0.415f, 0.485f, 72, 24);
            mata1.load(Constants.pathV + "shader.vert", Constants.pathV + "shader4.frag", Size.X, Size.Y);//mata putih
            _objectsDua.Add(mata1);

            var mulut = new Asset3d();
            mulut.createHalfEllipsoid(0.005f, 0.008f, 0.0f, 0.8f, 0.401f, 0.489f, 100, 100); //mulut
            mulut.load(Constants.pathV + "shader.vert", Constants.pathV + "shader5.frag", Size.X, Size.Y);//mulut
            _objectsDua.Add(mulut);

            var bahuKanan = new Asset3d();
            bahuKanan.createEllipsoid2(0.0030f, 0.0030f, 0.0f, 0.803f, 0.412f, 0.5f, 72, 24);
            bahuKanan.load(Constants.pathV + "shader.vert", Constants.pathV + "shader.frag", Size.X, Size.Y);
            _objectsDua.Add(bahuKanan); // parent 2

            //tangan
            var tanganKanan = new Asset3d();
            tanganKanan.createCylinder(0.001f, 0.025f, 0.81f, 0.425f, 0.5f);
            tanganKanan.load(Constants.pathV + "shader.vert", Constants.pathV + "shader.frag", Size.X, Size.Y);
            _objectsDua.Add(tanganKanan);

            var tanganKiri = new Asset3d();
            tanganKiri.createCylinder(0.001f, 0.025f, 0.79f, 0.425f, 0.5f);
            tanganKiri.load(Constants.pathV + "shader.vert", Constants.pathV + "shader.frag", Size.X, Size.Y);
            _objectsDua.Add(tanganKiri);

            //kaki kanan
            var kakiKanan = new Asset3d();
            kakiKanan.createCylinder(0.001f, 0.02f, 0.805f, 0.3757f, 0.5f);
            kakiKanan.load(Constants.pathV + "shader.vert", Constants.pathV + "shader.frag", Size.X, Size.Y);
            _objectsDua.Add(kakiKanan);

            //kaki kiri
            var kakiKiri = new Asset3d();
            kakiKiri.createCylinder(0.001f, 0.02f, 0.795f, 0.3757f, 0.5f);
            kakiKiri.load(Constants.pathV + "shader.vert", Constants.pathV + "shader.frag", Size.X, Size.Y);
            _objectsDua.Add(kakiKiri);

            //botol

            var ujung = new Asset3d();
            ujung.createHalfEllipsoid(0.01f, 0.017f, 0.01f, 0.8f, 0.47f, 0.5f, 100, 100);
            ujung.load(Constants.pathV + "shader.vert", Constants.pathV + "shader7.frag", Size.X, Size.Y);
            _objectsBotol.Add(ujung);
            //ujung.rotate(_objectsDua[0]._centerPosition, _objectsDua[0]._euler[1], (float)3);

            var botol = new Asset3d();
            botol.createCylinder(0.010f, 0.04f, 0.8f, 0.45f, 0.5f);

            botol.load(Constants.pathV + "shader.vert", Constants.pathV + "shader6.frag", Size.X, Size.Y);
            _objectsBotol.Add(botol); //



            //var alis2 = new Asset3d();
            //alis2.createBoxVertices2(-0.05f, 0.23f, 0.05f, 0.1f);
            //alis2.load(Constants.path + "shader.vert", Constants.path + "shader8.frag", Size.X, Size.Y);//alis kanan
            //alis.Child.Add(alis2);

            //KAREN
            //KAREN
            var kepalaK = new Asset3d();
            kepalaK.createBoxVertices(0.8f, 0.33f, 0.5f, 0.07f);// kepala depan
            kepalaK.load(Constants.pathR + "shader.vert", Constants.pathR + "shader2.frag", Size.X, Size.Y);
            karen.Add(kepalaK);

            var kepala2 = new Asset3d();
            kepala2.createTrapesium(0.8f, 0.33f, 0.55f, 0.06f); //kepala belakang
            kepala2.load(Constants.pathR + "shader.vert", Constants.pathR + "shader.frag", Size.X, Size.Y);
            karen.Add(kepala2);

            var muka = new Asset3d();
            muka.createBoxVertices(0.8f, 0.33f, 0.493f, 0.06f);// kepala depan
            muka.load(Constants.pathR + "shader.vert", Constants.pathR + "shader6.frag", Size.X, Size.Y);
            karen.Add(muka);

            var leher = new Asset3d();
            leher.createCylinder(0.005f, 0.12f, 0.8f, 0.25f, 0.5f); //leher
            leher.load(Constants.pathR + "shader.vert", Constants.pathR + "shader6.frag", Size.X, Size.Y);
            karen.Add(leher);

            var kaki = new Asset3d();
            kaki.createTrapesiumKAKI(0.8f, 0.177f, 0.5f, 0.05f);// kaki
            kaki.load(Constants.pathR + "shader.vert", Constants.pathR + "shader.frag", Size.X, Size.Y);
            karen.Add(kaki);

            var roda1 = new Asset3d();
            roda1.createEllipsoid(0.01f, 0.015f, 0.01f, 0.77f, 0.116f, 0.47f); //roda1
            roda1.load(Constants.pathR + "shader.vert", Constants.pathR + "shader6.frag", Size.X, Size.Y);
            karen.Add(roda1);

            var roda2 = new Asset3d();
            roda2.createEllipsoid(0.01f, 0.015f, 0.01f, 0.83f, 0.116f, 0.47f); //roda2 belakang kanan
            roda2.load(Constants.pathR + "shader.vert", Constants.pathR + "shader6.frag", Size.X, Size.Y);
            karen.Add(roda2);

            var roda3 = new Asset3d();
            roda3.createEllipsoid(0.01f, 0.015f, 0.01f, 0.77f, 0.116f, 0.53f); //roda3 kiri depan
            roda3.load(Constants.pathR + "shader.vert", Constants.pathR + "shader6.frag", Size.X, Size.Y);
            karen.Add(roda3);

            var roda4 = new Asset3d();
            roda4.createEllipsoid(0.01f, 0.015f, 0.01f, 0.83f, 0.116f, 0.53f); //roda4 kanan depan
            roda4.load(Constants.pathR + "shader.vert", Constants.pathR + "shader6.frag", Size.X, Size.Y);
            karen.Add(roda4);

            var pelangi1 = new Asset3d(new List<Vector3> { (0.05f, 2.2f, 2.0f), (0.0f, 5.7f, -0.2f), (1.0f, 0.6f, -1.2f) }, new List<uint> { });
            pelangi1.createCurveBezier();
            pelangi1.load(Constants.path + "shader.vert", Constants.path + "shader3.frag", Size.X, Size.Y);
            pelangi.Add(pelangi1);

            var pelangi2 = new Asset3d(new List<Vector3> { (0.04f, 2.19f, 1.99f), (-0.01f, 5.69f, -0.21f), (0.99f, 0.59f, -1.21f) }, new List<uint> { });
            pelangi2.createCurveBezier();
            pelangi2.load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);
            pelangi.Add(pelangi2);

            var pelangi3 = new Asset3d(new List<Vector3> { (0.03f, 2.18f, 1.98f), (-0.02f, 5.68f, -0.22f), (0.98f, 0.58f, -1.22f) }, new List<uint> { });
            pelangi3.createCurveBezier();
            pelangi3.load(Constants.path + "shader.vert", Constants.path + "shader4.frag", Size.X, Size.Y);
            pelangi.Add(pelangi3);

            CursorGrabbed = true;


            //_object3d[0] = new Asset3d();
            //_object3d[1] = new Asset3d();
            //_object3d[2] = new Asset3d();
            //_object3d[3] = new Asset3d();
            //_object3d[4] = new Asset3d();
            //_object3d[5] = new Asset3d();
            //_object3d[6] = new Asset3d();
            //_object3d[7] = new Asset3d();
            //_object3d[8] = new Asset3d();
            //_object3d[9] = new Asset3d();
            //_object3d[10] = new Asset3d();
            //_object3d[11] = new Asset3d();
            //_object3d[12] = new Asset3d();
            //_object3d[13] = new Asset3d();
            //_object3d[7].createBoxVertices(0.1f, 0.0f, 0, 0.5f); //alis


            // //mata putih

            //_object3d[5].createHalfEllipsoid(0.1f, -0.10f, 0.1f, 0.00f, 0.15f, -0.001f);//kepala

            //; //tangan kiri
            // //kaki kanan
            //_object3d[11] //kaki kiri
            // //botol
            //_object3d[13] //botol pucuk
            //_object3d[0].addChild(0.5f, 0.5f, 0.0f, 0.25f);
            //_object3d[0].addChildElipsoid(0.05f, 0.08f, 0.0f, 0.00f, 0.10f, 0.9f);



            //_object3d[4].load(Constants.path + "shader.vert", Constants.path + "shader5.frag", Size.X, Size.Y);//mulut


            // //tangan kanan
            //_object3d[9].load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y); //tangan kiri
            //_object3d[10].load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y); //kaki kanan
            //_object3d[11].load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y); //kaki kiri

            // //Botol
            //_object3d[7].load(Constants.path + "shader.vert", Constants.path + "shader6.frag", Size.X, Size.Y);//alis

            _camera = new Camera(new Vector3(0, 0, 2.5f), Size.X / Size.Y);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {

            base.OnRenderFrame(args);
            float time = (float)args.Time; //Deltatime ==> waktu antara frame sebelumnya ke frame berikutnya, gunakan untuk animasi
            totalTime = totalTime + time;
            float time_char = (float)args.Time;
            base.OnRenderFrame(args);


            _time += 9.0 * args.Time;
            degr += MathHelper.RadiansToDegrees(20f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            _time += 9.0 * args.Time;
            Matrix4 temp = Matrix4.Identity;
            Matrix4 miring = Matrix4.Identity;
            miring = miring * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(0.0f, 0.0f, 0.0f);

            //temp = temp * Matrix4.CreateTranslation(degr);
            //_objects[1].rotate(_objects[1]._centerPosition, _objects[0]._euler[1], (float)10);
            //_objects[2].rotate(_objects[2]._centerPosition, _objects[2]._euler[1], (float)3);
            //_object3d[9].rotate(new Vector3(0.0f,1.0f,0.0f), _object3d[9]._euler[0], (float)100.0);
            //_object3d[9]._model = Matrix4.CreateTranslation(0.0f, -1.0f * 0.5f, 0.0f);
            ////_object3d[2].rotate(_object3d[0]._centerPosition, _object3d[0]._euler[1], (float)3);
            //_object3d[3].rotate(_object3d[0]._centerPosition, _object3d[0]._euler[1], (float)3);
            //_object3d[4].rotate(_object3d[0]._centerPosition, _object3d[0]._euler[1], (float)3);
            //_object3d[0].Child[0].rotate(_object3d[0].Child[0]._centerPosition, _object3d[0].Child[0]._euler[0], 1);

            //_objects[0].renderK(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //tanah
            //_objects[1].renderK(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());//rumah petrik
            //_objects[2].renderK(1, _time, miring, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());//jednela
            //_objects[3].renderK(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //rumah hidung
            //_objects[4].renderK(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //rumah pintu
            //_objects1[0].renderK(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());//awan
            //_objects[5].renderK(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());//ubur


            //_objects[2].rotatede(_objects[2]._centerPosition, _objects[2]._euler[0], (float)3);
            //_objects[1].render(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_objects[2].render(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_objects[3].render(1, _time, miring, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_object3d[8].render(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_object3d[9].render(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_object3d[10].render(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_object3d[11].render(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_object3d[5].render(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_object3d[4].render(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_object3d[6].render(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_object3d[1].render(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_object3d[2].render(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_object3d[3].render(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_object3d[12].render(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_object3d[13].render(1, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_object3d[7].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            foreach (Asset3d i in pelangi)
            {


                i.renderV(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            foreach (Asset3d i in _objectsAwan)
            {
                i.rotatede(_objectsDua[0]._centerPosition, _objectsAwan[0]._euler[1], 90.0f * time);
                i.renderV(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                //foreach (Asset3d j in i.Child)
                //{

                //    j.translate(0.01f * speed, 0.0f, 0.0f);
                //}
                //i.translate(0.1f * speed, 0.0f, 0.0f);
            }
            //if (_objects1[0]._centerPosition.X >= 1.4f || _objects1[0]._centerPosition.X <= 0f)
            //{
            //    speed *= 1f;
            //}

            foreach (Asset3d i in _objects)
            {
               //i.rotate2(_objectsDua[0]._centerPosition, _objectsDua[0]._euler[0], 90.0f * time);
                i.renderV(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }

            //foreach (Asset3d i in _objectsV) // tangan bahu
            //{

            //    //i.rotatede(_objectsV[0]._centerPosition, _objectsV[0]._euler[0], 90.0f * time); //tangan muter diem di tmpt
            //    i.renderV(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //    //i.rotate(Vector3.Zero, Vector3.UnitY, 5 * time); // tangan muter keliling

            //}
            foreach (Asset3d i in _objects1)
            {
                i.renderV(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                foreach (Asset3d j in i.Child)
                {

                    j.translate(0.0f, 0.01f * speed2, 0.0f);
                }
                i.translate(0.0f, 0.01f * speed2, 0.0f);
            }
            if (_objects1[0]._centerPosition.Y >= 0.4f || _objects1[0]._centerPosition.Y <= 0.2f)
            {
                speed2 *= -1f;
            }
            foreach (Asset3d i in _objectsDua)
            {
                //i.rotate2(_objectsDua[0]._centerPosition, _objectsDua[0]._euler[0], 90.0f * time);
                i.renderV(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                foreach (Asset3d j in i.Child)
                {

                    j.translate(0.01f * speed, 0.0f, 0.0f);
                }
                i.translate(0.1f * speed, 0.0f, 0.0f);
            }
            if (_objectsDua[0]._centerPosition .X >= 1.4f || _objectsDua[0]._centerPosition.X <= 0f)
            {
                speed *= 1f;
            }

            //foreach (Asset3d i in _objectsDua) //badan kepala bokong kaki
            //{

            //    //i.rotate(_objectsV[0]._centerPosition, _objectsV[0]._euler[0], 90.0f * time);
            //    i.renderV(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //    //i.rotate(Vector3.Zero, Vector3.UnitY, 5 * time); //maju
            //    //i.rotate(_objectsDua[0]._centerPosition, Vector3.UnitY, 10 * time); // muter di tempat
            //}

            foreach (Asset3d j in _objectsBotol)
            {

                j.rotatede(karen[0]._centerPosition, karen[0]._euler[1], 45.0f * time);
                //j.translate(0, 0, -0.1f * time);
                j.renderV(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());

                j.rotatede(karen[0]._centerPosition, karen[0]._euler[0], 40.0f * time);
            }

            //foreach (Asset3d i in _objects1) //translate awan
            //{

            //    for (int j = 0; j < 3; j++)
            //    {

            //        i.translate(0.0f, 0.00f, 0.000000000000000000001f * time);

            //        if (j == 1)
            //            i.rotate(Vector3.Zero, Vector3.UnitY, 2 * time);
            //    }


            //}

            //_objectsDua[0].renderV(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_objectsDua[1].renderV(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_objectsDua[2].renderV(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            //KAREN
            //foreach (Asset3d j in karen)
            //{

            //    //_objects[4].render(1, _time, miring2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //    //j.rotate2(karen[0]._centerPosition, karen[0]._euler[1], 5);
            //    j.renderR(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //    //j.rotate2(karen[0]._centerPosition, Vector3.UnitY, 10 * time);
            //    //j.rotate(Vector3.Zero, Vector3.UnitY, 5 * time);
            //}

            foreach (Asset3d i in karen)
            {

                i.renderR(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                karen[4].rotatede(karen[4]._centerPosition, karen[4]._euler[1], 30 * time);
                karen[5].rotatede(karen[5]._centerPosition, karen[5]._euler[0], 30 * time);
                karen[6].rotatede(karen[6]._centerPosition, karen[6]._euler[0], 30 * time);
                karen[7].rotatede(karen[7]._centerPosition, karen[7]._euler[0], 30 * time);
                karen[8].rotatede(karen[8]._centerPosition, karen[8]._euler[0], 30 * time);
                foreach (Asset3d j in i.Child)
                {

                    j.translate(0.01f * speed, 0.0f, 0.0f);
                }
                i.translate(0.1f * speed, 0.0f, 0.0f);
            }
            if (karen[0]._centerPosition.X >= 1.4f || karen[0]._centerPosition.X <= 0f)
            {
                speed *= -1f;
            }

            //_object3d[0].resetEuler();

            //karen3[0].rotatede(karen3[0]._centerPosition, karen3[0]._euler[0], 30);
            //karen4[0].rotatede(karen4[0]._centerPosition, karen4[0]._euler[0], 30);
            //karen5[0].rotatede(karen5[0]._centerPosition, karen5[0]._euler[0], 30);
            //karen6[0].rotatede(karen6[0]._centerPosition, karen6[0]._euler[0], 30);

            //foreach (Asset3d j in karen)
            //{

            //    //j.rotate2(karen[0]._centerPosition, karen[0]._euler[1], 4);
            //    //j.rotate(Vector3.Zero, Vector3.UnitY, 2 * time);
            //    //j.translate(0, 0, -0.1f * time);
            //    //j.renderR(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //    //j.rotate2(karen[0]._centerPosition, Vector3.UnitY, 10 * time);

            //    //j.rotate(_objectsBotol[0]._centerPosition, Vector3.UnitY, 10 * time);
            //}

            foreach (Asset3d j in karen2)
            {

                //j.rotate2(karen2[0]._centerPosition, karen2[0]._euler[1], 4);
                //j.translate(0, 0, -0.1f * time);
                j.renderR(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                //j.rotate(Vector3.Zero, Vector3.UnitY, 5 * time);


            }
            foreach (Asset3d j in karen3)
            {

                //j.rotate2(karen3[0]._centerPosition, karen3[0]._euler[1], 4);
                //j.translate(0, 0, -0.1f * time);
                j.renderR(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                //j.rotate(Vector3.Zero, Vector3.UnitY, 5 * time);


            }
            foreach (Asset3d j in karen4)
            {

                //j.rotate2(karen4[0]._centerPosition, karen4[0]._euler[1], 4);
                //j.translate(0, 0, -0.1f * time);
                j.renderR(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                //j.rotate(Vector3.Zero, Vector3.UnitY, 5 * time);


            }
            foreach (Asset3d j in karen5)
            {

                //j.rotate2(karen5[0]._centerPosition, karen5[0]._euler[1], 4);
                //j.translate(0, 0, -0.1f * time);
                j.renderR(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                //j.rotate(Vector3.Zero, Vector3.UnitY, 5 * time);


            }
            foreach (Asset3d j in karen6)
            {

                //j.rotate2(karen6[0]._centerPosition, karen6[0]._euler[1], 4);
                //j.translate(0, 0, -0.1f * time);
                j.renderR(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                //j.rotate(Vector3.Zero, Vector3.UnitY, 5 * time);


            }




            //_objects[0].Child[0].rotate(_object3d[0].Child[0]._centerPosition, _object3d[0].Child[0]._euler[0], 1);
            //karen[0].renderR(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //karen2[0].renderR(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //karen2[1].renderR(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //karen3[0].renderR(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //karen4[0].renderR(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //karen5[0].renderR(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //karen6[0].renderR(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());


            SwapBuffers();
        }
    

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
            _camera.AspectRatio = Size.X / (float)Size.Y;
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
            float cameraSpeed = 0.5f;
            if (KeyboardState.IsKeyDown(Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.LeftShift))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time;
            }
            var mouse = MouseState;
            var sensitivity = 0.2f;
            if (_firstMove)
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse.X - _lastPos.X;
                var deltaY = mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity;
            }

            if (KeyboardState.IsKeyDown(Keys.N))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objecPost;
                _camera.Yaw += _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objecPost, _rotationSpeed).ExtractRotation());
                _camera.Position += _objecPost;

                _camera._front = -Vector3.Normalize(_camera.Position - _objecPost);
            }
            if (KeyboardState.IsKeyDown(Keys.Comma))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objecPost;
                _camera.Yaw -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objecPost, -_rotationSpeed).ExtractRotation());
                _camera.Position += _objecPost;

                _camera._front = -Vector3.Normalize(_camera.Position - _objecPost);
            }
            if (KeyboardState.IsKeyDown(Keys.K))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objecPost;
                _camera.Pitch -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objecPost, _rotationSpeed).ExtractRotation());
                _camera.Position += _objecPost;
                _camera._front = -Vector3.Normalize(_camera.Position - _objecPost);
            }
            if (KeyboardState.IsKeyDown(Keys.M))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objecPost;
                _camera.Pitch += _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objecPost, -_rotationSpeed).ExtractRotation());
                _camera.Position += _objecPost;
                _camera._front = -Vector3.Normalize(_camera.Position - _objecPost);
            }
        }
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButton.Left)
            {
                float _x = (MousePosition.X - Size.X / 2) / (Size.X / 2);
                float _y = -(MousePosition.Y - Size.Y / 2) / (Size.Y / 2);

                Console.WriteLine("x = " + _x + "y = " + _y);
            }
        }
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            Console.WriteLine("Offset Y: " + e.OffsetY);
            Console.WriteLine("Offset X: " + e.OffsetX);
            _camera.Fov = _camera.Fov - e.OffsetY;
        }
        public Matrix4 generateArbRotationMatrix(Vector3 axis, Vector3 center, float degree)
        {
            var rads = MathHelper.DegreesToRadians(degree);

            var secretFormula = new float[4, 4] {
                { (float)Math.Cos(rads) + (float)Math.Pow(axis.X, 2) * (1 - (float)Math.Cos(rads)), axis.X* axis.Y * (1 - (float)Math.Cos(rads)) - axis.Z * (float)Math.Sin(rads),    axis.X * axis.Z * (1 - (float)Math.Cos(rads)) + axis.Y * (float)Math.Sin(rads),   0 },
                { axis.Y * axis.X * (1 - (float)Math.Cos(rads)) + axis.Z * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Y, 2) * (1 - (float)Math.Cos(rads)), axis.Y * axis.Z * (1 - (float)Math.Cos(rads)) - axis.X * (float)Math.Sin(rads),   0 },
                { axis.Z * axis.X * (1 - (float)Math.Cos(rads)) - axis.Y * (float)Math.Sin(rads),   axis.Z * axis.Y * (1 - (float)Math.Cos(rads)) + axis.X * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Z, 2) * (1 - (float)Math.Cos(rads)), 0 },
                { 0, 0, 0, 1}
            };
            var secretFormulaMatix = new Matrix4
            (
                new Vector4(secretFormula[0, 0], secretFormula[0, 1], secretFormula[0, 2], secretFormula[0, 3]),
                new Vector4(secretFormula[1, 0], secretFormula[1, 1], secretFormula[1, 2], secretFormula[1, 3]),
                new Vector4(secretFormula[2, 0], secretFormula[2, 1], secretFormula[2, 2], secretFormula[2, 3]),
                new Vector4(secretFormula[3, 0], secretFormula[3, 1], secretFormula[3, 2], secretFormula[3, 3])
            );

            return secretFormulaMatix;
        }

    }
}