<%@ Page Title="" Language="C#" MasterPageFile="~/Pharma.master" AutoEventWireup="true"
    CodeFile="Services.aspx.cs" Inherits="Services" %>

<asp:Content ID="Content3" ContentPlaceHolderID="titleContent" runat="Server">
    Services
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="services">
        <h1 class="PatientAndCustomerServices">Patient & Customer Services :
        </h1>
        <p>
            We offer a range of services to our patients and customers, all with the aim of
		achieving high levels of patient and customer care in a professional, caring environment:
        </p>
        <div style="float: left">
            <div class="featurebox">
                <h2>Services at a Glance:</h2>
                <ul>
                    <li><a href="#disp">Dispensing of Prescriptions</a></li>
                    <li><a href="#homedel">Repeat Dispensing</a></li>
                    <li><a href="#coldel">Prescription Collection &amp; Delivery</a> </li>
                    <li><a href="#emergency">Emergency Supplies</a></li>
                    <li><a href="#sync">Prescription Syncronisation</a></li>
                    <li><a href="#medcon">Medicine Containers</a></li>
                    <li><a href="#mot">Prescription MOTs</a></li>
                    <li><a href="#oldmed">Disposal of unwanted or out-of-date medicines</a></li>
                    <li><a href="#prod">Medicines &amp; Equipment Sales</a></li>
                </ul>
                <p>
                    In addition our <a href="#compsys">Pharmacy Computer System</a> keeps records of
				your prescribed medicines and helps check on drug interactions and adverse effects.
                </p>
            </div>
            <div class="featurebox">
                <h2>Additional Services :</h2>
                <ul>
                    <li><strong>Free</strong> NHS Medicines Use Review</li>
                    <li><strong>Free</strong> Blood Pressure Monitoring</li>
                    <li><strong>Free</strong> Diabetes Screening</li>
                    <li><strong>Free</strong> NHS Smoking Cessation Service</li>
                    <li>Health Advice &amp; Self Care </li>
                    <li>Prescription MOTs</li>
                    <li>Holiday Healthcare</li>
                    <li>Emergency Hormonal Contraception</li>
                </ul>
                <p>
                    Information on the above services can be found in <a href="Consultations.aspx">Health
					Checks, Advice & Consultations.</a>
                </p>
            </div>
        </div>
        <h1 class="ServicesInDetail">Services in Detail:</h1>
        <p>
            <strong><a name="disp" id="disp"></a>Dispensing of NHS &amp; Private Prescriptions:</strong>
            We dispense NHS &amp; private prescriptions and will give advice on how to get the
		most benefit from your medicines for patients from all practices. We keep a comprehensive
		stock of medicines and use fast and efficient wholesaler service to enable us to
		fill all prescriptions promptly.
        </p>
        <p>
            We dispense private prescriptions at competitive prices for a range of treatments
		and health supplements.
        </p>
        <p>
            <a name="homedel" id="homedel"></a><strong>Repeat Dispensing:</strong> We can dispense
		NHS repeat dispensing prescriptions issued by your doctor. Ask us for more information
		about this service.
        </p>
        <p>
            <strong><a name="coldel" id="coldel"></a>Prescription Collection &amp; Delivery:</strong>
            Please ask for details. We can also deliver your medicines if you are unable to
		visit us.
        </p>
        <p>
            <a name="emergency" id="emergency"></a><strong>Emergency Supplies:</strong> If you
		need one of your regular medicines in an emergency when you are unable to contact
		your doctor, we may be able to help. Remember that we are here to help you every
		day including weekends so get in touch with us as soon as you can.
        </p>
        <p>
            We must stress that this can only be done in genuine emergencies. We DO NOT charge
		for this service if you are registered with any of the local GP practices. If you
		would like more information about any of the services mentioned, please ask a member
		of staff or telephone the number above.
        </p>
        <p>
            <a name="sync" id="sync"></a><strong>Prescription Syncronisation:</strong> At the
		end of the month, are you left with lots of some tablets and not enough of others?
		We can help you put this right to save you time.
        </p>
        <p>
            <strong><a name="medcon" id="medcon"></a>Medicine Containers:</strong> All medicines
		are dispensed in child resistant containers unless you request us not to. Please
		remember: keep all medicines out of reach and sight of children. Our team can advise
		you on safe storage of medicines.
        </p>
        <p>
            <a href="Consultations.aspx"><strong>Health Checks, Advice &amp; Consultations</strong></a>
            services are available in our private Consultation Room.
        </p>
        <p>
            <strong><a name="oldmed" id="oldmed"></a>Disposal of unwanted or out-of-date medicines:</strong>
            Please return all unwanted medicines to the pharmacy where we will dispose of them
		safely. You can use a MeDispose&copy; bag available from our pharmacy for this purpose.
		In order to protect the safety of our staff, customers and the environment, when
		returning your unwanted medicines to this pharmacy, <a href="medicine_old_returnof01.aspx">please take a moment to answer these quick questions</a>.
        </p>
        <p>
            <strong></a>Medicine &amp; Equipment Sales</strong>:We keep a wide range of over the counter medicines and also
			vitamins and mineral supplements. </a>We can supply a range of equipment for
		health maintenance such as Blood Pressure Monitors, Blood Glucose Meters, Weighing
		Scales, Pregnancy Testing Kits, etc. <strong>We can also order any product upon request
			at competitive prices.</strong>
        </p>
        <p class="para_last">
            <strong><a name="compsys" id="compsys"></a>Pharmacy Computer System:</strong> Keeps
		records of your prescribed medicines, but also helps check for drug interactions
		and adverse effects. Checks can be made with medication bought over the counter.
        </p>
        <p>
            <img src="Assets/Images/nhs-pharmacy-logo-small.gif" alt="Providing NHS Services" width="62"
                height="70" class="logo01" />
            <img src="Assets/Images/nhs-services-logo-small.gif" alt="NHS Services Available Here" width="140"
                height="70" class="logo01" />
            <a href="http://www.nhsdirect.nhs.uk/" target="_blank">
                <img src="Assets/Images/nhs-direct.gif" alt="NHS Direct Call 0845 4647" width="121" height="50"
                    border="0" class="logo01" /></a>
        </p>
    </div>
</asp:Content>
