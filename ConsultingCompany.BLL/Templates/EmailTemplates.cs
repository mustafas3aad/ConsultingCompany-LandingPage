using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.BLL.Templates
{
    public static class EmailTemplates
    {
        public static string ConsultationRequestConfirmation(string fullName, string companyName, string serviceName)
        {
            return $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset='UTF-8'>
                    <style>
                        body {{
                            font-family: 'Segoe UI', Arial, sans-serif;
                            background-color: #f4f4f4;
                            margin: 0;
                            padding: 0;
                        }}
                        .container {{
                            max-width: 600px;
                            margin: 40px auto;
                            background-color: #ffffff;
                            border-radius: 8px;
                            overflow: hidden;
                            box-shadow: 0 2px 8px rgba(0,0,0,0.1);
                        }}
                        .header {{
                            background-color: #1a1a2e;
                            padding: 30px;
                            text-align: center;
                        }}
                        .header h1 {{
                            color: #ffffff;
                            margin: 0;
                            font-size: 24px;
                            letter-spacing: 1px;
                        }}
                        .body {{
                            padding: 40px 30px;
                            color: #333333;
                        }}
                        .body h2 {{
                            font-size: 20px;
                            color: #1a1a2e;
                        }}
                        .details-box {{
                            background-color: #f9f9f9;
                            border-left: 4px solid #1a1a2e;
                            padding: 15px 20px;
                            margin: 20px 0;
                            border-radius: 4px;
                        }}
                        .details-box p {{
                            margin: 8px 0;
                            font-size: 15px;
                        }}
                        .details-box span {{
                            font-weight: bold;
                            color: #1a1a2e;
                        }}
                        .footer {{
                            background-color: #f4f4f4;
                            text-align: center;
                            padding: 20px;
                            font-size: 13px;
                            color: #888888;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>Consulting Company</h1>
                        </div>
                        <div class='body'>
                            <h2>Thank you, {fullName}!</h2>
                            <p>We have successfully received your consultation request. Our team will review it and get back to you as soon as possible.</p>

                            <div class='details-box'>
                                <p><span>Full Name:</span> {fullName}</p>
                                <p><span>Company:</span> {companyName}</p>
                                <p><span>Requested Service:</span> {serviceName}</p>
                            </div>

                            <p>If you have any questions, feel free to reply to this email.</p>
                            <p>Best regards,<br><strong>Consulting Company Team</strong></p>
                        </div>
                        <div class='footer'>
                            &copy; {DateTime.Now.Year} Consulting Company. All rights reserved.
                        </div>
                    </div>
                </body>
                </html>";
        }


        public static string NewsletterSubscriptionConfirmation(string email)
        {
            return $@"
                    <!DOCTYPE html>
                    <html>
                    <head>
                        <meta charset='UTF-8'>
                        <style>
                            body {{
                                font-family: 'Segoe UI', Arial, sans-serif;
                                background-color: #f4f4f4;
                                margin: 0;
                                padding: 0;
                            }}
                            .container {{
                                max-width: 600px;
                                margin: 40px auto;
                                background-color: #ffffff;
                                border-radius: 8px;
                                overflow: hidden;
                                box-shadow: 0 2px 8px rgba(0,0,0,0.1);
                            }}
                            .header {{
                                background-color: #1a1a2e;
                                padding: 30px;
                                text-align: center;
                            }}
                            .header h1 {{
                                color: #ffffff;
                                margin: 0;
                                font-size: 24px;
                                letter-spacing: 1px;
                            }}
                            .body {{
                                padding: 40px 30px;
                                color: #333333;
                                text-align: center;
                            }}
                            .body h2 {{
                                font-size: 20px;
                                color: #1a1a2e;
                            }}
                            .email-box {{
                                background-color: #f9f9f9;
                                border-left: 4px solid #1a1a2e;
                                padding: 15px 20px;
                                margin: 20px 0;
                                border-radius: 4px;
                                text-align: left;
                            }}
                            .email-box p {{
                                margin: 8px 0;
                                font-size: 15px;
                            }}
                            .email-box span {{
                                font-weight: bold;
                                color: #1a1a2e;
                            }}
                            .footer {{
                                background-color: #f4f4f4;
                                text-align: center;
                                padding: 20px;
                                font-size: 13px;
                                color: #888888;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class='container'>
                            <div class='header'>
                                <h1>Consulting Company</h1>
                            </div>
                            <div class='body'>
                                <h2>You're now subscribed! 🎉</h2>
                                <p>Thank you for subscribing to our newsletter. You will now receive our latest news and updates.</p>

                                <div class='email-box'>
                                    <p><span>Subscribed Email:</span> {email}</p>
                                </div>

                                <p>If you did not subscribe, please ignore this email.</p>
                                <p>Best regards,<br><strong>Consulting Company Team</strong></p>
                            </div>
                            <div class='footer'>
                                &copy; {DateTime.Now.Year} Consulting Company. All rights reserved.
                            </div>
                        </div>
                    </body>
                    </html>";
        }
    }
}
