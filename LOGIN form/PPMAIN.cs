using Falcon_X_Cheat;
using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DiscordRPC;
using System.Web.UI.WebControls;
namespace LOGIN_form
{
    public partial class PPMAIN : Form
    {
        public PPMAIN()
        {
            InitializeComponent();
        }
        public void Alert(string msg, FXMSG.enmType type)
        {
            FXMSG frm = new FXMSG();
            frm.showAlert(msg, type);
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
        PerformanceCounter perfRAM = new PerformanceCounter("Memory", "Available MBytes");
        PerformanceCounter PerfCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");


        public DateTime UnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            try
            {
                dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            }
            catch
            {
                dtDateTime = DateTime.MaxValue;
            }
            return dtDateTime;
        }

public string expirydaysleft()
{
    System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
    dtDateTime = dtDateTime.AddSeconds(long.Parse(Form1.KeyAuthApp.user_data.subscriptions[0].expiry)).ToLocalTime();
    TimeSpan difference = dtDateTime - DateTime.Now;
    return Convert.ToString(difference.Days + " Days " + difference.Hours + " Hours Left");
}
        private void PPMAIN_Load(object sender, EventArgs e)
        {

            //VERSION
            VRS.Text = "SALVATORS XIT" + Form1.KeyAuthApp.app_data.version;
          //USERNAME 
          USERNAME .Text = "Username :" + Form1.KeyAuthApp.user_data.username;
          //EXPIRY DATE
           EXPIRYDATE.Text = "Expiry Date : " + UnixTimeToDateTime(long.Parse(Form1.KeyAuthApp.user_data.subscriptions[0].expiry));
            //SUB TYPE
             SUBTYPE.Text = "Subscription : " + Form1.KeyAuthApp.user_data.subscriptions[0].subscription;
           //IP
           IPADRESS.Text = "IP Address : " + Form1.KeyAuthApp.user_data.ip;
          //HWID
            HWID.Text = "HWID : " + Form1.KeyAuthApp.user_data.hwid;
          // CRAT DATE
             CREATDATE.Text = "Creation Date : " + UnixTimeToDateTime(long.Parse(Form1.KeyAuthApp.user_data.createdate));
           //LAST LOGIN
           LASTLOGIN.Text = "Last Login : " + UnixTimeToDateTime(long.Parse(Form1.KeyAuthApp.user_data.lastlogin));
        // ESP DAYS
         EXPIRYINDAYS.Text = "Expiry in Days : " + expirydaysleft();

            //CPU NAME :
            string CPUName = Convert.ToString(Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\SYSTEM\\CentralProcessor\\0", "ProcessorNameString", null));
            cpuname.Text = ("CPU NAME : " + CPUName);



            discordrpc.rpctimestamp = Timestamps.Now;
            discordrpc.InitializeRPC();
        }
        Mem salvators = new Mem();
    
           

        private async void aimbot_CheckedChanged(object sender, EventArgs e)
        {
            if (aimbot.Checked)
            {
                string search = "62 6F 6E 65 5F 4E 65 63 6B 62 6F 6E 65 5F 53 70 69 6E 65 31 42 61 73 65 20 4C 61 79 65 72 2E 53 68 6F 77 46 69 73 74 42 61 73 65 20 4C 61 79 65 72 2E 53 74 61 6E 64 49 64 6C 65 42 61 73 65 20";
                string replace = "62 6F 6E 65 5F 4E 65 63 73 62 6F 6E 65 5F 53 70 69 6E 65 31 42 61 73 65 20 4C 61 79 65 72 2E 53 68 6F 77 46 69 73 74 42 61 73 65 20 4C 61 79 65 72 2E 53 74 61 6E 64 49 64 6C 65 42 61 73 65 20";
                string search1 = "62 6F 6E 65 5F 48 69 70 73 62 6F 6E 65 5F 4C 65 66 74 54 6F 65 62 6F 6E 65 5F 52 69 67 68 74 54 6F 65 49 53 56 49 53 49 42 4C 45 5F 43 41 4D 45 52 41 20 20 20 49 53 56 49 53 49 42 4C 45 5F 56 45 48 49 43 4C 45";
                string replace1 = "62 6F 6E 65 5F 4E 65 63 6B 62 6F 6E 65 5F 4C 65 66 74 54 6F 65 62 6F 6E 65 5F 52 69 67 68 74 54 6F 65 49 53 56 49 53 49 42 4C 45 5F 43 41 4D 45 52 41 20 20 20 49 53 56 49 53 49 42 4C 45 5F 56 45 48 49 43 4C 45";

                bool k = false;

                if (Process.GetProcessesByName("HD-Player").Length == 0)
                {
                    // error
                    this.Alert("Open Emulateur", FXMSG.enmType.Error);//Error//Applying
                }
                else
                {
                    salvators.OpenProcess("HD-Player");
                    // Applying
                    this.Alert("Activating . . . ", FXMSG.enmType.Applying);//Error//Applying
                    int i2 = 22000000;
                    IEnumerable<long> wl = await salvators.AoBScan(search, writable: true);

                    string u = "0x" + wl.FirstOrDefault().ToString("X");
                    if (wl.Count() != 0)
                    {
                        for (int i = 0; i < wl.Count(); i++)
                        {
                            i2++;
                            salvators.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                        }
                        k = true;
                    }

                    if (k)
                    {
                        // Applied
                        this.Alert("Applied", FXMSG.enmType.Applied);//Error//Applying
                        Console.Beep(250, 300);
                    }
                    else
                    {
                        // error
                        this.Alert("Failed", FXMSG.enmType.Error);//Error//Applying
                    }
                }
            }
        }

        private async void quickswitch_CheckedChanged(object sender, EventArgs e)
        {
            if (quickswitch.Checked)
            {
                string search = "?? ?? ?? 3F 00 00 80 3E 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 80 3F";
                string replace = "EC 51 B8 3D 8F C2 F5 3C";

                bool k = false;

                if (Process.GetProcessesByName("HD-Player").Length == 0)
                {
                    // error
                    this.Alert("Open Emulateur", FXMSG.enmType.Error);//Error//Applying
                }
                else
                {
                    salvators.OpenProcess("HD-Player");
                    // Applying
                    this.Alert("Activating . . . ", FXMSG.enmType.Applying);//Error//Applying
                    int i2 = 22000000;
                    IEnumerable<long> wl = await salvators.AoBScan(search, writable: true);

                    string u = "0x" + wl.FirstOrDefault().ToString("X");
                    if (wl.Count() != 0)
                    {
                        for (int i = 0; i < wl.Count(); i++)
                        {
                            i2++;
                            salvators.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                        }
                        k = true;
                    }

                    if (k)
                    {
                        // Applied
                        this.Alert("Applied", FXMSG.enmType.Applied);//Error//Applying
                        Console.Beep(250, 300);
                    }
                    else
                    {
                        // error
                        this.Alert("Failed", FXMSG.enmType.Error);//Error//Applying
                    }
                }
            }
        }

        private async void aimsniper_CheckedChanged(object sender, EventArgs e)
        {
            if (aimsniper.Checked)
            {
                string search = "CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 07 00 00 00 00 00 00 00";
                string replace = "E0 B1 FF FF E0 B1 FF FF E0 B1 FF FF E0 B1 FF FF E0 B1 FF FF";

                bool k = false;

                if (Process.GetProcessesByName("HD-Player").Length == 0)
                {
                    // error
                    this.Alert("Open Emulateur", FXMSG.enmType.Error);//Error//Applying
                }
                else
                {
                    salvators.OpenProcess("HD-Player");
                    // Applying
                    this.Alert("Activating . . . ", FXMSG.enmType.Applying);//Error//Applying
                    int i2 = 22000000;
                    IEnumerable<long> wl = await salvators.AoBScan(search, writable: true);

                    string u = "0x" + wl.FirstOrDefault().ToString("X");
                    if (wl.Count() != 0)
                    {
                        for (int i = 0; i < wl.Count(); i++)
                        {
                            i2++;
                            salvators.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                        }
                        k = true;
                    }

                    if (k)
                    {
                        // Applied
                        this.Alert("Applied", FXMSG.enmType.Applied);//Error//Applying
                        Console.Beep(250, 300);
                    }
                    else
                    {
                        // error
                        this.Alert("Failed", FXMSG.enmType.Error);//Error//Applying
                    }
                }
            }
        }
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
        uint dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
        const int PROCESS_CREATE_THREAD = 0x0002;
        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_READ = 0x0010;
        const uint MEM_COMMIT = 0x00001000;
        const uint MEM_RESERVE = 0x00002000;
        const uint PAGE_READWRITE = 4;
        private WebClient webclient = new WebClient();
        private  void antena_CheckedChanged(object sender, EventArgs e)
        {
            string fileName = "C:\\Windows\\System32\\FX_CHAMS.dll";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "https://cdn.discordapp.com/attachments/1221001014476410910/1224036881243574406/FX_CHAMS.dll?ex=661c082d&is=6609932d&hm=1b3634474680643228c5eff8243c965db9f7ffef2d9fa6cedd913c8361b26c2a&";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            Process targetProcess = Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "FX_CHAMS.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
        }
            
           

        private async void noscoupeawm_CheckedChanged(object sender, EventArgs e)
        {
            if (noscoupeawm.Checked)
            {
                string search = "01 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 01 00 00 00 ?? ?? ?? 3F 01 00 00 00 ?? ?? ?? 3F 00 00 00 00";
                string replace = "0000";

                bool k = false;

                if (Process.GetProcessesByName("HD-Player").Length == 0)
                {
                    // error
                    this.Alert("Open Emulateur", FXMSG.enmType.Error);//Error//Applying
                }
                else
                {
                    salvators.OpenProcess("HD-Player");
                    // Applying
                    this.Alert("Activating . . . ", FXMSG.enmType.Applying);//Error//Applying
                    int i2 = 22000000;
                    IEnumerable<long> wl = await salvators.AoBScan(search, writable: true);

                    string u = "0x" + wl.FirstOrDefault().ToString("X");
                    if (wl.Count() != 0)
                    {
                        for (int i = 0; i < wl.Count(); i++)
                        {
                            i2++;
                            salvators.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                        }
                        k = true;
                    }

                    if (k)
                    {
                        // Applied
                        this.Alert("Applied", FXMSG.enmType.Applied);//Error//Applying
                        Console.Beep(250, 300);
                    }
                    else
                    {
                        // error
                        this.Alert("Failed", FXMSG.enmType.Error);//Error//Applying
                    }
                }
            }
        }

        private async void startstopbs_CheckedChanged(object sender, EventArgs e)
        {
            if (startstopbs.Checked)
            {
                string programDirectory = @"C:\Program Files\BlueStacks_nxt\";
                string instance = "--instance Nougat32";

                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = Path.Combine(programDirectory, "HD-Player.exe"),
                        Arguments = instance,
                        UseShellExecute = true
                    };

                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    this.Alert("BlueStack 5 Not Fund !", FXMSG.enmType.Error);//Error//Applying
                }

            }
            else
            {
                string processName = "HD-Player";

                // Get all processes with the specified name
                Process[] processes = Process.GetProcessesByName(processName);

                // Terminate each process
                foreach (Process process in processes)
                {
                    try
                    {
                        process.Kill();
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions, if any
                        Console.WriteLine($"Error terminating process: {ex.Message}");
                    }
                }
            }
        }
           

        private async void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked)
            {
                string search = "4C 7B 5A BD 0A 57 66 BB 1E 21 48 BA 2A C2 CF 3B 96 FB 28 3D E8 B1 17 BD E3 99 7F 3F 04 00 80 3F 01 00 80 3F FC FF 7F 3F ?? ?? ?? ?? 23 AA A6 B8 46 0A CD 70 00 00 00 00";
                string replace = "D1 0A C0 BE 16 DC 98 BD BB 82 97 B4 00 00 00 00 BF B2 2F 3F 43 32 73 36 66 03 7B 35 72 1C C7 3F 72 1C C7 3F 72 1C C7 3F";
                string search1 = "10 00 00 00 62 00 6F 00 6E 00 65 00 5F 00 4C 00 65 00 66 00 74 00 5F 00 57 00 65 00 61 00 70 00 6F 00 6E 00 00 00 ?? ?? ?? ?? ?? ?? 00 00 00 00 0E";
                string replace1 = "10 00 00 00 62 00 6F 00 6E 00 65 00 5F 00 48 00 65 00 61 00 64 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";
                string search2 = "23 AA A6 B8 46 0A CD 70";
                string replace2 = "23 AA A6 B8 B2 F7 1F A4";
                string search3 = "47 7B 5A BD AE 57 66 BB 5C 1F 48 BA 1B C0 CF 3B 9C FB 28 3D A2 B1 17 BD E4 99 7F 3F 04 00 80 3F 00 00 80 3F FE FF 7F 3F";
                string replace3 = "BF 87 BF BE 16 DC 98 BD BB 82 97 B4 00 00 00 00 BF B2 2F 3F 43 32 73 36 66 03 7B 35 72 1C C7 3F 72 1C C7 3F 72 1C C7 3F";

                bool k = false;

                if (Process.GetProcessesByName("HD-Player").Length == 0)
                {
                    // error
                    this.Alert("Open Emulateur", FXMSG.enmType.Error);//Error//Applying
                }
                else
                {
                    salvators.OpenProcess("HD-Player");
                    // Applying
                    this.Alert("Activating . . . ", FXMSG.enmType.Applying);//Error//Applying
                    int i2 = 22000000;
                    IEnumerable<long> wl = await salvators.AoBScan(search, writable: true);

                    string u = "0x" + wl.FirstOrDefault().ToString("X");
                    if (wl.Count() != 0)
                    {
                        for (int i = 0; i < wl.Count(); i++)
                        {
                            i2++;
                            salvators.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                        }
                        k = true;
                    }

                    if (k)
                    {
                        // Applied
                        this.Alert("Applied", FXMSG.enmType.Applied);//Error//Applying
                        Console.Beep(250, 300);
                    }
                    else
                    {
                        // error
                        this.Alert("Failed", FXMSG.enmType.Error);//Error//Applying
                    }
                }
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        public void ExecuteCommand(string command)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();

                // Write the command to the command prompt
                process.StandardInput.WriteLine(command);
                process.StandardInput.Flush();
                process.StandardInput.Close();

                // Wait for the command to finish
                process.WaitForExit();
            }
        }
        private async void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch2.Checked)
            {
                ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=in action=block profile=any program=\"C:\\Program Files\\BlueStacks\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=out action=block profile=any program=\"C:\\Program Files\\BlueStacks\\HD-Player.exe\"");
            }
            else
            {
                ExecuteCommand("netsh advfirewall firewall delete rule name=all program=\"C:\\Program Files\\BlueStacks\\HD-Player.exe\"");
            }

        }


        private void label12_Click(object sender, EventArgs e)
        {

        }

        private async void guna2ToggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch3.Checked)
            {
                string search = "78 63 68 61 6E 67 65 00 6D 62 65 64 74 6C 73 5F 64 68 6D 5F 63 61 6C 63 5F 73 65 63";
                string replace = " 00 F0 20 E3";
                string search1 = "5F 70 75 62 6C 69 63 00 A4 C4 60 00 44 48 4D 3A 20 47 59 00 D1 D6 60 00 1C C5 60 00";
                string replace1 = "00 F0 20 E3";
                string search2 = "5F 70 75 62 6C 69 63 00 A4 C4 60 00 44 48 4D 3A 20 47 59 00 D1 D6 60 00 1C C5 60 00";
                string replace2 = "00 F0 20 E3";
                string search3 = "08 00 9D E5 08 10 D0 E5 0D 00 51 E3 03 00 00 0A 08 00 9D E5 08 10 D0 E5 0E 00 51 E3";
                string replace3 = "00 00 00 00";


                bool k = false;

                if (Process.GetProcessesByName("HD-Player").Length == 0)
                {
                    // error
                    this.Alert("Open Emulateur", FXMSG.enmType.Error);//Error//Applying
                }
                else
                {
                    salvators.OpenProcess("HD-Player");
                    // Applying
                    this.Alert("Activating . . . ", FXMSG.enmType.Applying);//Error//Applying
                    int i2 = 22000000;
                    IEnumerable<long> wl = await salvators.AoBScan(search, writable: true);

                    string u = "0x" + wl.FirstOrDefault().ToString("X");
                    if (wl.Count() != 0)
                    {
                        for (int i = 0; i < wl.Count(); i++)
                        {
                            i2++;
                            salvators.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                        }
                        k = true;
                    }

                    if (k)
                    {
                        // Applied
                        this.Alert("Applied", FXMSG.enmType.Applied);//Error//Applying
                        Console.Beep(250, 300);
                    }
                    else
                    {
                        // error
                        this.Alert("Failed", FXMSG.enmType.Error);//Error//Applying
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //CPU USAGE :
            cpuusage.Text = "CPU USAGE : " + (int)PerfCPU.NextValue() + " " + "%";
            //RAM USAGE:
            ramusage.Text = "RAM USAGE: " + (int)perfRAM.NextValue() + " " + "MB";
        }

        private void cpuname_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }


















